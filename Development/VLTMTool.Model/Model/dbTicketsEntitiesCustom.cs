using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.Model.Model
{
    public partial class VLTMModelConnection : DbContext
    {
        public VLTMModelConnection(String connectionString) : base(connectionString)
        {
        }
    }
}
