using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMtemp_vTechnicalUsers
    {
        public VMtemp_vTechnicalUsers()
        {

        }
        public int IdTechnical { get; set; }
        public string TechnicalUser { get; set; }
        public string TechnicalName { get; set; }

        public List<VMTickets> Tickets { get; set; }
    }
}
