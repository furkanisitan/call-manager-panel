using System.Web.Security;
using CallManagerPanel.Core.CrossCuttingConcerns.Security.Principal;

namespace CallManagerPanel.Core.CrossCuttingConcerns.Security.Web
{
    public static class SecurityUtilities
    {
        /// <summary>
        /// // ticket'ı işleyerek Identity nesnesine çevirir.
        /// </summary>
        public static Identity FormsAuthenticationTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var tags = ticket.UserData.Split('|');

            return new Identity
            {
                Name = ticket.Name,
                AuthenticationType = nameof(FormsAuthentication),
                IsAuthenticated = true,
                Fullname = tags[0],
                Id = int.Parse(tags[1]),
                Roles = tags[2].Split(',')
            };
        }
    }
}
