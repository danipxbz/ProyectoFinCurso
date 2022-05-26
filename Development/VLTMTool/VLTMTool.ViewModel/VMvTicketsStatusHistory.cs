using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMvTicketsStatusHistory
    {
        public System.DateTime StatusDate { get; set; }
        public string User { get; set; }
        public string StatusName { get; set; }
        public Nullable<int> AsignedTo { get; set; }
        public string ResolvedVersion { get; set; }
        public int IdTicket { get; set; }
        public int IdStatus { get; set; }
        public int Expr1 { get; set; }
    }
}
