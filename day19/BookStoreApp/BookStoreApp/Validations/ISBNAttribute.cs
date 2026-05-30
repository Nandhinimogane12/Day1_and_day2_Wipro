using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookStoreApp.Validations
{
    public class ISBNAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            string isbn = value.ToString()!;
            // ISBN-13: 978-0-123456-47-2 or 9780123456472
            return Regex.IsMatch(isbn, @"^(?:ISBN(?:-1[03])?:? )?(?=[0-9X]{10}$|(?=(?:[0-9]+[- ]){3})[- 0-9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)(?:97[89][- ]?)?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9X]$");
        }
    }
}