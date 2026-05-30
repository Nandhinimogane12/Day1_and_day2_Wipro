using BookStoreApp.Models;

namespace BookStoreApp.Services
{
    public interface ICartService
    {
        List<CartItem> GetCartItems();
        void AddToCart(Book book);
        void RemoveFromCart(int bookId);
        void ClearCart();
    }

    public class CartItem
    {
        public Book Book { get; set; } = new();
        public int Quantity { get; set; }
    }
}