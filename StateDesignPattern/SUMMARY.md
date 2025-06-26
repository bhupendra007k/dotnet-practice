# State Design Pattern — Notes (with BankAccount Example)

---

## What is the State Design Pattern?

A behavioral design pattern that lets an object alter its behavior when its internal state changes, as if the object changed its class at runtime.

Instead of using long `if-else` or `switch` statements, it delegates state-specific behavior to different **state classes**.

---

## Where it’s Applied in the BankAccount Example

**Context**:

* `BankAccount` class delegates actions like `Login()`, `Logout()`, `WithdrawMoney()` to its `CurrentState`.

**State Interface**:

* `BankAccountState` abstract class defines the actions available in all states.

**Concrete States**:

* `LoggedIn`, `LoggedOut`, `Suspended` classes implement state-specific behavior and manage transitions to other states.

**Behavior Delegation**:

* `BankAccount` forwards actions to `CurrentState`.
* Each state class decides what to do:

  * Process the action.
  * Possibly change the state.
  * Return the current state info.

---

## When to Use the State Design Pattern

Use when:

* An object’s behavior depends on its internal state.
* You need to avoid complex and scattered `if-else` or `switch` blocks controlling state transitions.
* The number of states or the behavior per state is expected to grow or change.
* You need to encapsulate state-specific behavior cleanly and independently.

**Example**:
Bank Account, Authentication flow, UI component modes (edit/view/disabled), Network connection state, Media player (playing/paused/stopped)

---

## When Not to Use It

Avoid when:

* The number of states is very small and unlikely to grow.
* State transitions are very simple and infrequent.
* Overhead of creating multiple classes isn’t justified.
* Project size/scope is too small for the added structural complexity.

**Example**:
If your object only toggles between two states with no complex behavior, a simple `bool` or enum flag is likely enough.

---

## Advantages

* Clean separation of concerns. Each state’s behavior is encapsulated in its own class.
* Simplifies context class by removing the need to manage transitions or behaviors.
* Easier to add new states without modifying existing ones (Open/Closed Principle).
* Improves maintainability. Each state’s code is isolated and easier to test, debug, or modify.
* Avoids tight coupling. Context delegates behavior to its state; context doesn’t need to know about state-specific logic.

---

## Disadvantages

* Increased number of classes. For every possible state, you need a separate class.
* Might be overkill for simple state logic. Adds complexity if there are only 2-3 trivial states.
* Harder to trace code flow, as behavior is distributed across multiple classes; requires understanding state transitions well.

---

## Summary

* State Design Pattern allows an object’s behavior to change based on its internal state.
* Avoids scattered `if-else`/`switch` checks in the context class.
* Uses state objects to encapsulate state-specific behavior.
* Applied cleanly in the BankAccount example:

  * `BankAccount` delegates to `CurrentState`.
  * `LoggedIn`, `LoggedOut`, `Suspended` handle logic and transitions.
* Best for systems with multiple, distinct states and frequent transitions.
* Avoid if the system is too simple, as it may introduce unnecessary complexity.
