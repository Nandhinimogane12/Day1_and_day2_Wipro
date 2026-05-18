using System.ComponentModel.DataAnnotations;

namespace CustomerFeedbackPortal.Validators
{
    /// <summary>
    /// Custom validation to demonstrate extending Data Annotations
    /// Note: [Compare] already does this, but this shows how to build custom ones
    /// </summary>
    public class PasswordMatchAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.UserRegistration)validationContext.ObjectInstance;

            if (model.Password != model.ConfirmPassword)
            {
                return new ValidationResult("Password and Confirm Password must match");
            }
            return ValidationResult.Success;
        }
    }
}