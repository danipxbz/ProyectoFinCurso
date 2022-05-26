using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMTicketsMessagesHistory
    {
        public int IdTicket { get; set; }
        public System.DateTime MessageDate { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
    }
}
