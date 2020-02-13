namespace CallManagerPanel.MVCWebUI.Models
{
    public class UserVm : IViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Roles { get; set; }
    }
}