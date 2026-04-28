using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LSP Demonstration
            IPayment payment = new CardPayment();
            payment.Pay();

            payment = new UPIPayment();
            payment.Pay();

            payment = new NetBankingPayment();
            payment.Pay();

            Console.WriteLine("------------------");

            // DIP Demonstration
            INotification notification = new EmailNotification();

            WalletService wallet = new WalletService(payment, notification);
            wallet.ProcessPayment();

            Console.ReadLine();
        }
    }
}
