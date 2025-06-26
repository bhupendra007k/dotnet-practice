// See https://aka.ms/new-console-template for more information
using BankAccountStatePattern;

var account = new BankAccount(5000m, "pass123", "reset456");

Console.WriteLine($"🔵 Initial State: {account.CurrentState.GetType().Name}");
Console.WriteLine();

// Attempt to withdraw money while LoggedOut
Console.WriteLine("Attempting to withdraw 1000 while LoggedOut:");
var result = account.WithdrawMoney(1000);
PrintStatus(account, result);

// Login with wrong password
Console.WriteLine("Login attempt with 'wrong1':");
result = account.Login("wrong1");
PrintStatus(account, result);

// Login with another wrong password
Console.WriteLine("Login attempt with 'wrong2':");
result = account.Login("wrong2");
PrintStatus(account, result);

// Correct login
Console.WriteLine("Login attempt with 'pass123':");
result = account.Login("pass123");
PrintStatus(account, result);

// Withdraw money while LoggedIn
Console.WriteLine("Withdrawing 2000 while LoggedIn:");
result = account.WithdrawMoney(2000);
PrintStatus(account, result);

// Logout
Console.WriteLine("Logging out:");
result = account.Logout();
PrintStatus(account, result);

// Trigger suspension: 3 wrong logins
Console.WriteLine("Login with 'badpass':");
account.Login("badpass");
Console.WriteLine("Login with 'badpass':");
account.Login("badpass");
Console.WriteLine("Login with 'badpass':");
result = account.Login("badpass");
PrintStatus(account, result);

// Try unlock with wrong reset code
Console.WriteLine("Unlocking with 'wrongcode':");
result = account.Unlock("wrongcode");
PrintStatus(account, result);

// Unlock with correct reset code
Console.WriteLine("Unlocking with 'reset456':");
result = account.Unlock("reset456");
PrintStatus(account, result);


static void PrintStatus(BankAccount account, StateInfo stateInfo)
{
    Console.WriteLine($"➡️  Current State: {account.CurrentState.GetType().Name}");
    Console.WriteLine($"➡️  StateInfo Returned: {stateInfo}");
    Console.WriteLine($"➡️  Balance: {account.CashBalance}");
    Console.WriteLine($"➡️  Password Retries: {account.PasswordRetries}");
    Console.WriteLine();
}
