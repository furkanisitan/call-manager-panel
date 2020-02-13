using System.Threading;

namespace CallManagerPanel.Core.CrossCuttingConcerns.Security.Principal
{
    public static class PrincipalHelper
    {
        public static ICustomPrincipal GetCustomPrincipal() =>
            Thread.CurrentPrincipal as ICustomPrincipal;

        public static int GetId() =>
            (Thread.CurrentPrincipal as ICustomPrincipal)?.Id ?? 0;

        public static string GetFullname() =>
            (Thread.CurrentPrincipal as ICustomPrincipal)?.Fullname;
    }
}
