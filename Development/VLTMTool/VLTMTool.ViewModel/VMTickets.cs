using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLTMTool.ViewModel
{
    public class VMTickets
    {
        public VMTickets()
        {
            TicketsAccessHistory = new List<VMTicketsAccessHistory>();
            TicketsStatusHistory = new List<VMTicketsStatusHistory>();
            TicketsMessagesHistory = new List<VMTicketsMessagesHistory>();
        }
        
        //Contructor for new Tickets since Form of Ticket Gestion
        public VMTickets(DateTime date, string user)
        {
            this.TicketDate = date;
            this.User = user;
            //Debemos inicializar todas las listas aqui.
            TicketsAccessHistory = new List<VMTicketsAccessHistory>();
            TicketsStatusHistory = new List<VMTicketsStatusHistory>();
            TicketsMessagesHistory = new List<VMTicketsMessagesHistory>();
        }
        public int IdTicket { get; set; }
        public System.DateTime TicketDate { get; set; }
        public string User { get; set; }
        public int IdType { get; set; }
        public string AppCode { get; set; }
        public int IdSection { get; set; }
        public string AppVersion { get; set; }
        public string SourceIdentification { get; set; }
        public Nullable<int> PriorityLevel { get; set; }
        public Nullable<int> PriorityAsignedTo { get; set; }
        public Nullable<int> AsignedTo { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }
        public string ImageFile1 { get; set; }
        public string ImageFile2 { get; set; }
        public string ImageFile3 { get; set; }
        public string ImageFile4 { get; set; }
        public List<VMTicketsAccessHistory> TicketsAccessHistory { get; set; }
        public VMTicketsExceptionInfo TicketsExceptionInfo { get; set; }
        public List<VMTicketsMessagesHistory> TicketsMessagesHistory { get; set; }
        public List<VMTicketsStatusHistory> TicketsStatusHistory { get; set; }

    }
}
