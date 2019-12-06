using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCaveDesktop.ViewModels
{
    class TicketDetailViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
        public bool Resolved { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string SenderId { get; set; }
        public string SenderUsername { get; set; }
    }
}
