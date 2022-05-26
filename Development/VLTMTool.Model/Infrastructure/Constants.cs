using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.Model.Infrastructure
{
    public class Constants
    {
        // Ruta al fichero de configuración
        public const string PATH_CONFIG_FILE = @"C:\tecnologica\VCPFSConfig.dat";
        // Usuario de acceso a la base de datos
        public const string DB_USER = "tecnologica";
        //public const string DB_USER = "sa";
        // Password de acceso a la base de datos
        public const string DB_PASS = "tecnologica";
        //public const string DB_PASS = "rvajfd-d01";

        public const string DEFAULTFILEPATH = "K:\\PL\\VLData\\Tickets";
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
        public const string TECHNIC_ADMIN = "RPEREZ";
        public const int TYPE_INTERNAL_INCIDENCE = 1;
        public const int TYPE_ERROR = 2;
        public const int TYPE_INCORRECT_FUNCTIONALITY = 3;
        public const int TYPE_UPGRADE = 4;
        public const int TYPE_SUPPORT_REQUEST = 5;
        public const int HEIGHT_ROW_GRID_TICKETS = 22;
    }
}
