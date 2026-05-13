using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Validations
{
    public class PriceRangeAttribute : ValidationAttribute
    {
        private readonly double _min;
        private readonly double _max;

        public PriceRangeAttribute(double min, double max)
        {
            _min = min;
            _max = max;
            ErrorMessage = $"Price must be between {_min} and {_max}";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            double price = Convert.ToDouble(value);
            return price >= _min && price <= _max;
        }
    }
}