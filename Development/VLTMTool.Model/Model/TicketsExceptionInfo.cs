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
    
    public partial class TicketsExceptionInfo
    {
        public int IdTicket { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionTrace { get; set; }
    
        public virtual Tickets Tickets { get; set; }
    }
}