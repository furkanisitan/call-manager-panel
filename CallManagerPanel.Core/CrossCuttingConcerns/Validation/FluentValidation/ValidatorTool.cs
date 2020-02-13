using CallManagerPanel.Core.Entities;
using FluentValidation;
using System.Linq;

namespace CallManagerPanel.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        /// <summary>
        /// 'validator'ı kullanarak entity nesnesi üzerinde model doğrulaması yapar.
        /// Hata durumunda ValidationException fırlatır.
        /// </summary>
        public static void FluentValidate<T>(IValidator<T> validator, T entity, string ruleSet) where T : class, IEntity, new()
        {
            var result = validator.Validate(entity, ruleSet: ruleSet);
            if (result.Errors.Any())
                throw new ValidationException(result.Errors);
        }
    }
}
