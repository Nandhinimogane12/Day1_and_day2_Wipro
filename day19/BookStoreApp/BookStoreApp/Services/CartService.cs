using BookStoreApp.Models;

namespace BookStoreApp.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartSessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<CartItem> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext!.Session;
            var cart = session.GetObjectFromJson<List<CartItem>>(CartSessionKey);
            return cart ?? new List<CartItem>();
        }

        public void AddToCart(Book book)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(i => i.Book.Id == book.Id);
            if (item == null)
                cart.Add(new CartItem { Book = book, Quantity = 1 });
            else
                item.Quantity++;

            _httpContextAccessor.HttpContext!.Session.SetObjectAsJson(CartSessionKey, cart);
        }

        public void RemoveFromCart(int bookId)
        {
            var cart = GetCartItems();
            cart.RemoveAll(i => i.Book.Id == bookId);
            _httpContextAccessor.HttpContext!.Session.SetObjectAsJson(CartSessionKey, cart);
        }

        public void ClearCart() => _httpContextAccessor.HttpContext!.Session.Remove(CartSessionKey);
    }

    // Session extension methods
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
            => session.SetString(key, System.Text.Json.JsonSerializer.Serialize(value));

        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : System.Text.Json.JsonSerializer.Deserialize<T>(value);
        }
    }
}