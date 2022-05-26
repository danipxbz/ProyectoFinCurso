using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class ListPriorities
    {
        public List <Priority> listPriorities = new List<Priority>();
        public ListPriorities()
        {
            for (int i = 1; i <= 5; i++)
            {
                Priority p = new Priority()
                {
                    Value = i,
                    Display = i.ToString()
                };
                listPriorities.Add(p);
            }
        }
    }
}
