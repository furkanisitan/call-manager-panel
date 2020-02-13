using System;
using System.Linq;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace CallManagerPanel.Core.Aspects.Postsharp.AuthorizationAspects
{
    /// <summary>
    /// Method gövdesini çalıştırabilmek için gereken yetki kontrolünü sağlar.
    /// </summary>
    [PSerializable]
    public class AuthorizationAspect : OnMethodBoundaryAspect
    {
        private string[] _roles;

        public AuthorizationAspect(params string[] roles)
        {
            _roles = roles;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            // Kullanıcı, parametre olarak verilen rollerden hiçbirini sağlamıyorsa hata fırlatır.
            if (_roles.All(x => !System.Threading.Thread.CurrentPrincipal.IsInRole(x)))
                throw new Exception("You are not authorized!");
        }
    }
}
