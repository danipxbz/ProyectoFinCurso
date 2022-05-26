using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMvTHOREmployes
    {
        public string EmployeeCode { get; set; }
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public string Subdepartment { get; set; }
        public string Email { get; set; }
        public Nullable<bool> AllowImputation { get; set; }
        public string HolidaysCalendar { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
