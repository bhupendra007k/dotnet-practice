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
        public BankAccount(decimal cashBalance, string password, string resetCode) { }

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

        public LoggedIn(BankAccount account) { }

        public override StateInfo Login(string password)
        {
            throw new NotImplementedException();
        }
        public override StateInfo Logout()
        {
            throw new NotImplementedException();
        }
        public override StateInfo Unlock(string resetCode)
        {
            throw new NotImplementedException();
        }
        public override StateInfo WithdrawMoney(decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    // LoggedOut state class
    public class LoggedOut : BankAccountState
    {
        private readonly BankAccount _account;

        public LoggedOut(BankAccount account) { }

        public override StateInfo Login(string password)
        {
            throw new NotImplementedException();
        }
        public override StateInfo Logout()
        {
            throw new NotImplementedException();
        }
        public override StateInfo Unlock(string resetCode)
        {
            throw new NotImplementedException();
        }
        public override StateInfo WithdrawMoney(decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    // Suspended state class
    public class Suspended : BankAccountState
    {
        private readonly BankAccount _account;

        public Suspended(BankAccount account) { }

        public override StateInfo Login(string password)
        {
            throw new NotImplementedException();
        }
        public override StateInfo Logout()
        {
            throw new NotImplementedException();
        }
        public override StateInfo Unlock(string resetCode)
        {
            throw new NotImplementedException();
        }
        public override StateInfo WithdrawMoney(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}