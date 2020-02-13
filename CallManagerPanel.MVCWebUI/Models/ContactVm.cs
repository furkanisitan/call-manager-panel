using System;

namespace CallManagerPanel.MVCWebUI.Models
{
    public class ContactVm : IViewModel
    {
        public string Id { get; set; }
        public string Phone { get; set; }
        public string CallReason { get; set; }
        public string CallResult { get; set; }
        public DateTime Date { get; set; }
    }
}