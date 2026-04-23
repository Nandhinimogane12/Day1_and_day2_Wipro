using System;

// Custom Exception for Invalid Deposit Amount
class InvalidAmountException : Exception
{
    public InvalidAmountException(string message) : base(message)
    {
    }
}

// Custom Exception for Insufficient Balance
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}

// BankAccount Class
class BankAccount
{
    public string AccountHolderName { get; set; }
    public double Balance { get; set; }

    // Constructor
    public BankAccount(string name, double balance)
    {
        AccountHolderName = name;
        Balance = balance;
    }

    // Deposit Method
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new InvalidAmountException("Deposit amount must be greater than 0.");
        }

        Balance += amount;
        Console.WriteLine("Amount Deposited Successfully: Rs." + amount);
    }

    // Withdraw Method
    public void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            throw new InsufficientBalanceException("Withdrawal amount cannot exceed balance.");
        }

        if ((Balance - amount) < 1000)
        {
            throw new InsufficientBalanceException("Minimum balance of Rs.1000 must be maintained.");
        }

        Balance -= amount;
        Console.WriteLine("Amount Withdrawn Successfully: Rs." + amount);
    }

    // Check Balance Method
    public void CheckBalance()
    {
        Console.WriteLine("Current Balance: Rs." + Balance);
    }
}

// Main Program
class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount("Nandhini", 5000);

        try
        {
            Console.WriteLine("Bank Transaction System");
            Console.WriteLine("------------------------");

            // Check Initial Balance
            account.CheckBalance();

            // Deposit Money
            Console.WriteLine("\nDepositing Rs.2000...");
            account.Deposit(2000);

            // Withdraw Money
            Console.WriteLine("\nWithdrawing Rs.3000...");
            account.Withdraw(3000);

            // Invalid Deposit Example
            Console.WriteLine("\nDepositing Rs.0...");
            account.Deposit(0);

            // Invalid Withdraw Example
            Console.WriteLine("\nWithdrawing Rs.5000...");
            account.Withdraw(5000);
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine("InvalidAmountException: " + ex.Message);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("InsufficientBalanceException: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("ArgumentException: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("InvalidOperationException: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("\nTransaction Process Completed.");
        }
    }
}