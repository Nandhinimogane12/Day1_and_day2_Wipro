using System;

namespace ConsoleApp1
{
    // Poor Design (Violating SOLID)
    internal class MyWalletService
    {
        public void ProcessPayment1()
        {
            Console.WriteLine("Processing Payment");

            // Payment Logic
            Console.WriteLine("Payment done using Card");

            // Notification Logic
            Console.WriteLine("Email Notification Sent");

            // Save Transaction
            Console.WriteLine("Transaction Saved");
        }
    }

    // Step 1 : SRP (Single Responsibility Principle)

    public class TransactionService
    {
        public void SaveTransaction()
        {
            Console.WriteLine("Transaction Saved Successfully");
        }
    }

    public class PaymentService
    {
        public void MakePayment()
        {
            Console.WriteLine("Payment Completed");
        }
    }

    public class NotificationService
    {
        public void NotifyUser()
        {
            Console.WriteLine("Notification Sent");
        }
    }

    // Step 2 : OCP + DIP
    // IMPORTANT: make interface PUBLIC

    public interface IPayment
    {
        void Pay();
    }

    public class CardPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Payment done using Card");
        }
    }

    public class UPIPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Payment done using UPI");
        }
    }

    public class NetBankingPayment : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Payment done using Net Banking");
        }
    }

    // Step 3 : ISP
    // IMPORTANT: make interface PUBLIC

    public interface INotification
    {
        void SendMessage();
    }

    public class EmailNotification : INotification
    {
        public void SendMessage()
        {
            Console.WriteLine("Email Notification Sent");
        }
    }

    // Step 4 : DIP

    public class WalletService
    {
        private IPayment _payment;
        private INotification _notification;

        public WalletService(IPayment payment, INotification notification)
        {
            _payment = payment;
            _notification = notification;
        }

        public void ProcessPayment()
        {
            _payment.Pay();
            _notification.SendMessage();

            Console.WriteLine("Wallet Payment Processed Successfully");
        }
    }
}