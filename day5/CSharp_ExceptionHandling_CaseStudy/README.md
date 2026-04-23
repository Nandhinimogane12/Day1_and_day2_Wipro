# Bank Transaction System

## Problem Statement

Develop a Banking Transaction System using C# with Exception Handling.

Users can:
- Deposit money
- Withdraw money
- Check balance

Business Rules:
- Minimum balance should be Rs.1000
- Withdrawal amount cannot exceed balance
- Deposit amount must be greater than 0

The system should handle invalid scenarios using:
- Built-in Exceptions
- Try-Catch-Finally
- Custom Exceptions

## Exception Types Used

### Custom Exceptions
- InvalidAmountException
- InsufficientBalanceException

### Built-in Exceptions
- ArgumentException
- InvalidOperationException
- General Exception

## Sample Output

Bank Transaction System
------------------------
Current Balance: Rs.5000

Depositing Rs.2000...
Amount Deposited Successfully: Rs.2000

Withdrawing Rs.3000...
Amount Withdrawn Successfully: Rs.3000

Depositing Rs.0...
InvalidAmountException: Deposit amount must be greater than 0.

Transaction Process Completed.

## How to Run the Code

1. Open Visual Studio
2. Create a new Console Application
3. Copy the Program.cs code
4. Paste and Save
5. Click Run

