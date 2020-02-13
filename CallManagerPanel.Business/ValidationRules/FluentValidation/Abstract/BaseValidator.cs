using FluentValidation;

namespace CallManagerPanel.Business.ValidationRules.FluentValidation.Abstract
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        static BaseValidator()
        {
            // Hata mesajlarını yerel dile göre vermeyi devre dışı bırakır.
            ValidatorOptions.LanguageManager.Enabled = false;
        }
    }
}
