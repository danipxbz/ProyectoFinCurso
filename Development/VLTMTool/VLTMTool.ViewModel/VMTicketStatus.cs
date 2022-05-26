using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMTicketStatus
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public List<VMTicketsStatusHistory> TicketsStatusHistory { get; set; }
    }
}
