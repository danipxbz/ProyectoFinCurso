//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VLTMTool.Model.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class vTickets
    {
        public int IdTicket { get; set; }
        public System.DateTime TicketDate { get; set; }
        public int IdType { get; set; }
        public string TypeName { get; set; }
        public string AppCode { get; set; }
        public string AppName { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
        public Nullable<int> PriorityLevel { get; set; }
        public string AppVersion { get; set; }
        public Nullable<int> IdStatus { get; set; }
        public string StatusName { get; set; }
        public string Name { get; set; }
        public int IdSection { get; set; }
        public string AppSectionName { get; set; }
        public string Subject { get; set; }
    }
}
