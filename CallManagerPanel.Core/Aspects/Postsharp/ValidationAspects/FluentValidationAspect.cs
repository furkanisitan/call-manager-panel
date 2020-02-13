using CallManagerPanel.Core.CrossCuttingConcerns.Validation.FluentValidation;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Linq;

namespace CallManagerPanel.Core.Aspects.Postsharp.ValidationAspects
{
    /// <summary>
    /// Methoda verilen 'IEntity' parametresinin, tipi verilen (validatorType) validation sınıfının
    /// 'validate' methodunu kullanarak doğrulamasını yapar.
    /// </summary>
    [PSerializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private Type _validatorType;
        private string _ruleSet;

        public FluentValidationAspect(Type validatorType, string ruleSet = null)
        {
            _validatorType = validatorType;
            _ruleSet = ruleSet;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            // Validator sınıfın base sınıfında belirtilen generic tip parametrelerinden ilkini alır.
            // Örn: CallValidator : BaseValidator<Call> => Call
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];

            // Method'a 'entityType' tipinde verilen tüm parametreleri alır.
            // Örn: Contact Update(Contact contact) => contact
            var entities = args.Arguments.Where(x => x.GetType() == entityType);

            // Validation işlemi için ValidatorTool sınıfının FluentValidate methodu kullanılacaktır.
            // void FluentValidate<T>(IValidator<T> validator, T entity, string ruleSet) where T : class, IEntity, new()
            
            // FluentValidate methodu generic bir methoddur ve aldığı validator nesnesi de generic olarak belirtilmiştir.
            // Bunun en büyük sebebi 'IValidator' interface'inde 'ruleSet' parametresi geçilebilecek bir 'Validate' methodu
            // tanımı olmamadıdır. Bu tanım 'IValidator<T>' generic interface'inde mevcuttur.

            // 'entityType' tipi ile çalışma zamanında generic bir FluentValidate<T> methodu oluşturulur.
            // T: entityType
            var genericValidateMethod = typeof(ValidatorTool).GetMethod(nameof(ValidatorTool.FluentValidate))?.MakeGenericMethod(entityType);
            
            // '_validatorType' tipindeki validator sınıfından çalışma zamanında bir nesne oluşturulur.
            var validator = Activator.CreateInstance(_validatorType);

            foreach (var entity in entities)
                // İlgili parametreler 'FluentValidate' methoduna verilerek bu method çalıştırılır.
                // Validator sınıfının base sınıfı olan BaseValidator<T> sınıfı zaten IValidator<T> interface'inden miras
                // aldığı için validator nesnesi aynı zamanda IValidator<T> tipindedir.
                // Bu nedenle bu nesneyi 'FluentValidate' methoduna direkt olarak vermek bir sorun oluşturmaz.
                genericValidateMethod?.Invoke(null, new[] { validator, entity, _ruleSet });

        }
    }
}