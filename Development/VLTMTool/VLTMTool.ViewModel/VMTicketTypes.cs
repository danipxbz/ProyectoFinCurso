using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMTicketTypes
    {
        public int IdType { get; set; }
        public string TypeName { get; set; }
        public List<VMTickets> Tickets { get; set; }

    }
}
