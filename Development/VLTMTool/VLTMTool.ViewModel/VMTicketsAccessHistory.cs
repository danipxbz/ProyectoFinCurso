using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMTicketsAccessHistory
    {
        public int IdTicket { get; set; }
        public System.DateTime AccessDate { get; set; }
        public string User { get; set; }
        public string AccessActivity { get; set; }
    }
}
