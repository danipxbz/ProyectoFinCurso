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
    
    public partial class vTicketsStatusHistory
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