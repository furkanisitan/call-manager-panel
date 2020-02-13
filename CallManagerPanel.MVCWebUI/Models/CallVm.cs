using System;

namespace CallManagerPanel.MVCWebUI.Models
{
    public class CallVm : IViewModel
    {
        public string Id { get; set; }
        public string ContactId { get; set; }
        public string UserId { get; set; }
        public string UserFullname { get; set; }
        public DateTime Date { get; set; }
        public bool IsAccess { get; set; }
    }
}