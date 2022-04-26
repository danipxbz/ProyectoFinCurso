using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool
{
    public class Constants
    {
        public const int IDTICKETERROR = 2;
        public const int STATUS_PENDING_ID = 1;
        public const string STATUS_PENDING_NAME = "Pending";
        public const int STATUS_ASSIGN_ID = 2;
        public const string STATUS_ASSIGN_NAME = "Assign to Technic";
        public const int STATUS_RESOLVE_VERSION_ID = 3;
        public const string STATUS_RESOLVE_VERSION_NAME = "Resolve. Pending for version";
        public const int STATUS_RESOLVE_VALIDATION_ID = 4;
        public const string STATUS_RESOLVE_VALIDATION_NAME = "Resolve. Pending for user validation";
        public const int STATUS_CLOSE_ID = 5;
        public const string STATUS_CLOSE_NAME = "Close";
        public const int STATUS_DELETE_ID = 6;
        public const string STATUS_DELETE_NAME = "Delete";
    }
}
