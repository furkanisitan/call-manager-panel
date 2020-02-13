using CallManagerPanel.Business.Abstract;
using CallManagerPanel.Business.DependencyResolvers.Ninject;
using CallManagerPanel.Business.ValidationRules.FluentValidation.Abstract;
using CallManagerPanel.Business.ValidationRules.FluentValidation.HelperValidators;
using CallManagerPanel.Entities.Concrete;
using FluentValidation;

namespace CallManagerPanel.Business.ValidationRules.FluentValidation
{
    public class ContactValidator : BaseValidator<Contact>
    {
        private static readonly IContactService ContactService;

        static ContactValidator()
        {
            ContactService = InstanceFactory.GetInstance<IContactService>();
        }

        public ContactValidator()
        {
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Phone).Must(HValidate.IsPhoneNumber).WithMessage("'{PropertyName}' is not valid.");
            RuleFor(x => x.CallReason).MaximumLength(200);
            RuleFor(x => x.CallResult).MaximumLength(200);

            RuleSet("update", () =>
            {
                When(x => ContactService.IsPropertiesEdited(x, nameof(x.Date)), () =>
                {
                    RuleFor(x => x.Date)
                        .Must(x => HValidate.IsAuthorized("Admin"))
                        .WithMessage("You are not authorized to change the '{PropertyName}'.");
                });

                When(x => ContactService.IsPropertiesEdited(x, nameof(x.Phone)), () =>
                {
                    RuleFor(x => x.Phone)
                        .Must(x => HValidate.IsAuthorized("Manager", "Admin"))
                        .WithMessage("You are not authorized to change the '{PropertyName}'.");
                });
            });
        }
    }
}
