using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMTicketsStatusHistory
    {
        public int IdTicket { get; set; }
        public System.DateTime StatusDate { get; set; }
        public int IdStatus { get; set; }
        public string User { get; set; }
        public Nullable<int> AsignedTo { get; set; }
        public string ResolvedVersion { get; set; }
        public Nullable<double> TimeForResolved { get; set; }

        public string StatusName { get; set; }
    }
}
