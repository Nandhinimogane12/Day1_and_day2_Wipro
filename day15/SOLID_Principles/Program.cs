using System;

namespace MovieBookingSOLID
{
    // =========================================================
    // SINGLE RESPONSIBILITY PRINCIPLE (SRP)
    // =========================================================

    //  WITHOUT SRP
    /*
    class MovieSystem
    {
        public void BookTicket() { }
        public void MakePayment() { }
        public void SendNotification() { }
    }
    */
    // "One class doing multiple jobs → violates SRP"

    // WITH SRP
    class BookingService
    {
        public void BookTicket(string movie, string seat)
        {
            Console.WriteLine($"Movie: {movie}, Seat: {seat} booked successfully.");
        }
    }

    class NotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Notification: " + message);
        }
    }

    // =========================================================
    // BAD DESIGN (NO OCP + DIP)
    // =========================================================

    /*
    class PaymentService
    {
        public void Pay(string type)
        {
            if (type == "UPI")
                Console.WriteLine("Paid using UPI");
            else if (type == "Card")
                Console.WriteLine("Paid using Card");
        }
    }
    */

    // "Adding new payment → need to modify class → violates OCP"
    // "Depends on conditions → violates DIP"

    // =========================================================
    // SOLID DESIGN (OCP + LSP + DIP)
    // =========================================================

    interface IPayment
    {
        void Pay(double amount);
    }

    class UPIPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid Rs.{amount} using UPI");
        }
    }

    class CardPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid Rs.{amount} using Card");
        }
    }

    class NetBankingPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid Rs.{amount} using NetBanking");
        }
    }

    // =========================================================
    // LSP VIOLATION EXAMPLE
    // =========================================================

    /*
    class WrongPayment : IPayment
    {
        public void Pay(double amount)
        {
            throw new Exception("Not supported");
        }
    }
    */

    // "Child class not behaving properly → violates LSP"

    // =========================================================
    // ISP VIOLATION EXAMPLE
    // =========================================================

    /*
    interface ISystem
    {
        void BookTicket();
        void Pay();
        void SendNotification();
    }

    class PaymentOnly : ISystem
    {
        public void BookTicket() { } // Not needed
        public void Pay() { Console.WriteLine("Paid"); }
        public void SendNotification() { } // Not needed
    }
    */

    // "Forcing unwanted methods → violates ISP"

    // =========================================================
    // FACTORY (FEATURE)
    // =========================================================

    class PaymentFactory
    {
        public static IPayment GetPayment(string type)
        {
            if (type.ToLower() == "upi")
                return new UPIPayment();
            else if (type.ToLower() == "card")
                return new CardPayment();
            else if (type.ToLower() == "netbanking")
                return new NetBankingPayment();
            else
                throw new Exception("Invalid Payment Type");
        }
    }

    // =========================================================
    // MAIN PROGRAM
    // =========================================================

    class Program
    {
        static void Main(string[] args)
        {
            BookingService booking = new BookingService();
            NotificationService notification = new NotificationService();

            Console.WriteLine("Enter Movie Name:");
            string movie = Console.ReadLine();

            Console.WriteLine("Enter Seat Number:");
            string seat = Console.ReadLine();

            booking.BookTicket(movie, seat);

            Console.WriteLine("Enter Payment Type (UPI/Card/NetBanking):");
            string type = Console.ReadLine();

            // "Using factory + interface → follows DIP and OCP"

            IPayment payment = PaymentFactory.GetPayment(type);
            payment.Pay(200);

            notification.SendNotification("Ticket booked successfully!");

            Console.ReadLine();
        }
    }
}
