using CallManagerPanel.Business.Abstract;
using CallManagerPanel.Business.DependencyResolvers.Ninject;
using CallManagerPanel.Business.ValidationRules.FluentValidation.Abstract;
using CallManagerPanel.Entities.Concrete;
using FluentValidation;

namespace CallManagerPanel.Business.ValidationRules.FluentValidation
{
    public class CallValidator : BaseValidator<Call>
    {
        private static readonly ICallService CallService;

        static CallValidator()
        {
            CallService = InstanceFactory.GetInstance<ICallService>();
        }

        public CallValidator()
        {
            RuleFor(x => x.ContactId).GreaterThan(0).WithMessage("'{PropertyName}' is not valid.");
            RuleFor(x => x.Date).NotEmpty();

            RuleSet("create", () =>
            {
                RuleFor(x => x)
                    .Must(x => CallService.GetCountByContactId(x.ContactId) < 10)
                    .WithMessage("The maximum limit has been reached. No more can be added.");
            });
        }
    }
}