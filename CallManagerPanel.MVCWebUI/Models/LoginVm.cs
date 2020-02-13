using CallManagerPanel.Entities.Concrete;

namespace CallManagerPanel.MVCWebUI.Models
{
    public class LoginVm
    {
        public User User { get; set; }
        public bool RememberMe { get; set; }
    }
}