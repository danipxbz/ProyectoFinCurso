using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMvTickets
    {
        public int IdTicket { get; set; }
        public System.DateTime TicketDate { get; set; }
        public int IdType { get; set; }
        public string TypeName { get; set; }
        public string AppCode { get; set; }
        public string AppName { get; set; }
        public int IdSection { get; set; }
        public string AppSectionName { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public Nullable<int> PriorityLevel { get; set; }
        public string AppVersion { get; set; }
        public Nullable<int> IdStatus { get; set; }
        public string StatusName { get; set; }
    }
}
