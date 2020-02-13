using System.Security.Principal;

namespace CallManagerPanel.Core.CrossCuttingConcerns.Security.Principal
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; }
        string Fullname { get; }
        string[] Roles { get; }
    }
}