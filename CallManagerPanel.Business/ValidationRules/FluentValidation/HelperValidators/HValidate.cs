using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace CallManagerPanel.Business.ValidationRules.FluentValidation.HelperValidators
{
    public static class HValidate
    {
        private static readonly Regex PhoneRegex;

        static HValidate()
        {
            PhoneRegex = new Regex(@"^\(\d{3}\) \d{3} \d{4}$");
        }

        /// <summary>
        /// Telefon numarasının geçerli olup olmadığını kontrol eder.
        /// </summary>
        public static bool IsPhoneNumber(string phone) =>
             !string.IsNullOrEmpty(phone) && PhoneRegex.IsMatch(phone);

        /// <summary>
        /// Verilen rollerden herhangi birinin oturum açmış kullanıcıda oluğ olmadığını kontrol eder.
        /// </summary>
        public static bool IsAuthorized(params string[] roles) =>
             roles.Any(x => Thread.CurrentPrincipal.IsInRole(x));
    }
}
