namespace SecureBankingApp.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}