using System;

namespace BankAccountStatePattern
{
    // Provided enum — do not modify
    public enum StateInfo
    {
        LoggedIn,
        LoggedOut,
        Suspended,
        Error
    }

    // Provided abstract class — do not modify
    public abstract class BankAccountState
    {
        public abstract StateInfo Login(string password);
        public abstract StateInfo Logout();
        public abstract StateInfo Unlock(string resetCode);
        public abstract StateInfo WithdrawMoney(decimal amount);
    }

    // BankAccount class
    public class BankAccount
    {
        // State instances
        public BankAccountState LoggedInState { get; private set; }
        public BankAccountState LoggedOutState { get; private set; }
        public BankAccountState SuspendedState { get; private set; }

        // Current active state
        public BankAccountState CurrentState { get; set; }

        // Account properties
        public decimal CashBalance { get; set; }
        public string Password { get; private set; }
        public string ResetCode { get; private set; }
        public int PasswordRetries { get; set; }

        // Constructor — only this should be implemented
        public BankAccount(decimal cashBalance, string password, string resetCode)
        {
            CashBalance = cashBalance;
            Password = password;
            ResetCode = resetCode;
            PasswordRetries = 0;

            LoggedInState = new LoggedIn(this);
            LoggedOutState = new LoggedOut(this);
            SuspendedState = new Suspended(this);

            // Initial state is LoggedOut
            CurrentState = LoggedOutState;
        }

        // These methods are helpers to forward actions to the current state
        public StateInfo Login(string password) => CurrentState.Login(password);
        public StateInfo Logout() => CurrentState.Logout();
        public StateInfo Unlock(string resetCode) => CurrentState.Unlock(resetCode);
        public StateInfo WithdrawMoney(decimal amount) => CurrentState.WithdrawMoney(amount);
    }

    // LoggedIn state class
    public class LoggedIn : BankAccountState
    {
        private readonly BankAccount _account;

        public LoggedIn(BankAccount account)
        {
            _account = account;
        }

        public override StateInfo Login(string password) => StateInfo.LoggedIn;
        public override StateInfo Logout()
        {
            _account.CurrentState = _account.LoggedOutState;
            return StateInfo.LoggedOut;
        }
        public override StateInfo Unlock(string resetCode) => StateInfo.LoggedIn;
        public override StateInfo WithdrawMoney(decimal amount)
        {
            if (amount <= _account.CashBalance)
            {
                _account.CashBalance -= amount;
            }
            return StateInfo.LoggedIn;
        }
    }

    // LoggedOut state class
    public class LoggedOut : BankAccountState
    {
        private readonly BankAccount _account;

        public LoggedOut(BankAccount account)
        {
            _account = account;
        }

        public override StateInfo Login(string password) {
            if (password == _account.Password)
            {
                _account.CurrentState = _account.LoggedInState;
                return StateInfo.LoggedIn;
            }
            else
            {
                _account.PasswordRetries++;
                if (_account.PasswordRetries >= 3)
                {
                    _account.CurrentState = _account.SuspendedState;
                    return StateInfo.Suspended;
                }
                return StateInfo.Error; // Wrong password
            }
        }
        public override StateInfo Logout() => StateInfo.LoggedOut;
        public override StateInfo Unlock(string resetCode) => StateInfo.LoggedOut;
        public override StateInfo WithdrawMoney(decimal amount) => StateInfo.LoggedOut;
    }

    // Suspended state class
    public class Suspended : BankAccountState
    {
        private readonly BankAccount _account;

        public Suspended(BankAccount account)
        {
            _account = account;
        }

        public override StateInfo Login(string password) => StateInfo.Suspended;
        public override StateInfo Logout() => StateInfo.Suspended;
        public override StateInfo Unlock(string resetCode)
        {
            if (resetCode == _account.ResetCode)
            {
                _account.PasswordRetries = 0;
                _account.CurrentState = _account.LoggedOutState;
                return StateInfo.LoggedOut;
            }
            return StateInfo.Suspended; 
        }
        public override StateInfo WithdrawMoney(decimal amount) => StateInfo.Suspended;
    }
}