using System;
using System.Collections.Generic;

class Transaction
{
    public string TransactionId;
    public double Amount;

    public Transaction(string transactionId, double amount)
    {
        TransactionId = transactionId;
        Amount = amount;
    }

    public void Display()
    {
        Console.WriteLine("Transaction ID: " + TransactionId);
        Console.WriteLine("Amount: " + Amount);
    }
}

class BankingSystem
{
    static void Main()
    {
        // List for transaction history
        List<Transaction> transactionHistory = new List<Transaction>();

        // Dictionary for account balances
        Dictionary<string, double> accountBalances = new Dictionary<string, double>();

        // Queue for pending transactions
        Queue<Transaction> pendingTransactions = new Queue<Transaction>();

        // Stack for rollback operations
        Stack<Transaction> rollbackStack = new Stack<Transaction>();

        // HashSet for unique transaction IDs
        HashSet<string> transactionIds = new HashSet<string>();

        // Adding account balances
        accountBalances["ACC101"] = 5000;
        accountBalances["ACC102"] = 3000;

        // Creating transactions
        Transaction t1 = new Transaction("T001", 1000);
        Transaction t2 = new Transaction("T002", 1500);
        Transaction t3 = new Transaction("T001", 2000); // Duplicate ID

        // Add transactions only if ID is unique
        if (transactionIds.Add(t1.TransactionId))
            pendingTransactions.Enqueue(t1);

        if (transactionIds.Add(t2.TransactionId))
            pendingTransactions.Enqueue(t2);

        if (transactionIds.Add(t3.TransactionId))
            pendingTransactions.Enqueue(t3);
        else
            Console.WriteLine("Duplicate Transaction ID: " + t3.TransactionId);

        // Process pending transactions
        Console.WriteLine("\nProcessing Transactions:");
        while (pendingTransactions.Count > 0)
        {
            Transaction current = pendingTransactions.Dequeue();

            // Deposit into ACC101
            accountBalances["ACC101"] += current.Amount;

            transactionHistory.Add(current);
            rollbackStack.Push(current);

            Console.WriteLine("Processed:");
            current.Display();
            Console.WriteLine();
        }

        // Display account balance
        Console.WriteLine("Updated Account Balance:");
        Console.WriteLine("ACC101 Balance: " + accountBalances["ACC101"]);

        // Rollback last transaction
        Console.WriteLine("\nRollback Last Transaction:");
        if (rollbackStack.Count > 0)
        {
            Transaction lastTransaction = rollbackStack.Pop();
            accountBalances["ACC101"] -= lastTransaction.Amount;

            Console.WriteLine("Rolled Back Transaction:");
            lastTransaction.Display();
            Console.WriteLine("Updated ACC101 Balance: " + accountBalances["ACC101"]);
        }

        // Display transaction history
        Console.WriteLine("\nTransaction History:");
        foreach (Transaction t in transactionHistory)
        {
            t.Display();
            Console.WriteLine();
        }
    }
}
