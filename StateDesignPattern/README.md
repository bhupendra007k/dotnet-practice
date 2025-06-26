## Problem Description

Implement a **State Design Pattern** solution for a **Bank Account System** that manages client operations on their accounts.
Your task is to provide concrete implementations for several classes extending the `BankAccountState` abstract class. You will also need to implement the constructor of the `BankAccount` class to initialize its state objects. The system should behave correctly based on its current internal state, following the State Design Pattern.

---

## Initial Code

The provided initial code contains the following:

* **`BankAccountState` abstract class**:
  Acts as the base for concrete states (`LoggedIn`, `LoggedOut`, and `Suspended`).
  **Do not modify this class.**

* **`BankAccount` class**:
  Represents a bank account with properties such as:

  * `LoggedInState`, `LoggedOutState`, and `SuspendedState`
  * Current `CashBalance`
  * `ResetCode`
  * `Password`
  * Incorrect password retry count

  **You should only modify the body of its constructor. Do not alter other parts of this class.**

* **`LoggedIn`**, **`LoggedOut`**, and **`Suspended`** classes:
  These classes are initially empty. You are required to provide proper implementations for them.

* **`StateInfo` enum**:
  Defines possible states that should be returned from the action methods.
  **Do not modify this enum.**
  Note: The `Error` state is a special case and should never be returned from any method.

---

## Requirements

1. **Your code must compile successfully.**

2. **Implement the body of the `BankAccount` constructor** to initialize its properties:

   * `CashBalance`, `Password`, and `ResetCode` should be set using the constructor’s parameters.
   * `LoggedInState` should be initialized as a new instance of the `LoggedIn` class.
   * `LoggedOutState` should be initialized as a new instance of the `LoggedOut` class.
   * `SuspendedState` should be initialized as a new instance of the `Suspended` class.

3. All `LoggedIn`, `LoggedOut`, and `Suspended` classes should correctly extend the `BankAccountState` abstract class.

4. Each of the `LoggedIn`, `LoggedOut`, and `Suspended` classes must have a constructor that receives an instance of `BankAccount` as a parameter. The `BankAccount` property in each class should be set to this parameter.

5. Implement the State Design Pattern logic for the Bank Account as follows:

---

### 🔹 If the current state is **`LoggedIn`**

* **`Login()`**: No change to the bank account’s internal state or properties.
* **`Logout()`**: Change the internal state to `LoggedOut`.
* **`Unlock()`**: No change to the bank account’s internal state or properties.
* **`WithdrawMoney()`**

  * Deduct the specified amount from `CashBalance`.
  * If the requested amount exceeds the available `CashBalance`, leave `CashBalance` unchanged.

---

### 🔹 If the current state is **`LoggedOut`**

* **`Login(string password)`**

  * If the password matches the `BankAccount.Password`, set the internal state to `LoggedIn`.
  * If the password is incorrect, increment `PasswordRetries` by 1.
  * If `PasswordRetries` exceeds 2, set the internal state to `Suspended`.
  * Password correctness is determined by comparing the provided password to the `Password` property.

* **`Logout()`**: No change to the bank account’s internal state or properties.

* **`Unlock()`**: No change to the bank account’s internal state or properties.

* **`WithdrawMoney()`**: No change to the bank account’s internal state or properties.

---

### 🔹 If the current state is **`Suspended`**

* **`Login()`**: No change to the bank account’s internal state or properties.

* **`Logout()`**: No change to the bank account’s internal state or properties.

* **`Unlock(string resetCode)`**

  * If the reset code matches `BankAccount.ResetCode`:

    * Set `PasswordRetries` to 0.
    * Change the internal state to `LoggedOut`.
  * If incorrect, no change occurs.
  * Reset code correctness is determined by comparing the provided reset code to the `ResetCode` property.

* **`WithdrawMoney()`**: No change to the bank account’s internal state or properties.

---

6. **Each of these methods should return a `StateInfo` enum value** representing the internal state of the `BankAccount` after the action:

* Return `StateInfo.LoggedIn` if the state is now `LoggedIn`.
* Return `StateInfo.LoggedOut` if the state is now `LoggedOut`.
* Return `StateInfo.Suspended` if the state is now `Suspended`.

---

## Assumptions

* The `LoggedIn`, `LoggedOut`, and `Suspended` classes always receive an instance of `BankAccount` through their constructors.
* Follow the **State Design Pattern** strictly — leave responsibility for state transitions and business logic within the respective state classes.
* The only modifications allowed are within:

  * The **`BankAccount` constructor**
  * The **`LoggedIn`**, **`LoggedOut`**, and **`Suspended`** classes

---

## Hints

* Use the existing `BankAccount` methods to help implement your state logic.
* Your solution will be evaluated solely on correctness. Performance and coding style will not be assessed.
* You may use `Console.WriteLine()` to debug outputs from your solution if needed.

---
