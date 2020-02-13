using System;
using System.Linq;
using System.Security.Principal;

namespace CallManagerPanel.Core.CrossCuttingConcerns.Security.Principal
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; }

        public int Id { get; }
        public string Fullname { get; }
        public string[] Roles { get; }

        public CustomPrincipal(Identity identity)
        {
            Identity = identity;

            Id = identity.Id;
            Fullname = identity.Fullname;
            Roles = identity.Roles;
        }
        public bool IsInRole(string role)
            => Roles.Contains(role, StringComparer.OrdinalIgnoreCase);
    }
}