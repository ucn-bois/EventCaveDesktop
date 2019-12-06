using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
        public bool Resolved { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string SenderId { get; set; }
        public string SenderUsername { get; set; }

        public override string ToString()
        {
            return String.Format("Subject: {0}, Message: {1}, Sender: {2}", Subject, Message, SenderUsername);
        }
    }
}
