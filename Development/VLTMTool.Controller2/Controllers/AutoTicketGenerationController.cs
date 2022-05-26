using AutoMapper;
using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Model.Model;
using VLTMTool.ViewModel;
using VLTMTool.Model.Services;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace VLTMTool.Controller2.Controllers
{
    public class AutoTicketGenerationController : ControllerBase
    {
        public AutoTicketGenerationController(ServiceBDBase serviceBase, IMapper mapper) : base(serviceBase, mapper)
        {
        }

        #region Domain to ViewModel
        public string GetLastUserChangeStatus(VMTickets ticket)
        {
            try
            {
                string lastUser = ticket.TicketsStatusHistory.OrderByDescending(x => x.StatusDate).Select(x => x.User).First();
                return lastUser;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        #endregion

        #region Save to BBDD
        public void SaveTicketMessage(VMTicketsMessagesHistory newTicketMessage)
        {
            try
            {
                TicketsMessagesHistory ticket = serviceBase.DbContext.TicketsMessagesHistory.Where(x => x.IdTicket == newTicketMessage.IdTicket && x.MessageDate == newTicketMessage.MessageDate).FirstOrDefault();

                if (ticket != null)
                {
                    serviceBase.DbContext.TicketsMessagesHistory.AddOrUpdate(ticket);
                }
                else
                {
                    ticket = new TicketsMessagesHistory();
                    mapper.Map(newTicketMessage, ticket, typeof(VMTicketsMessagesHistory), typeof(TicketsMessagesHistory));
                    serviceBase.DbContext.Entry(ticket).State = EntityState.Added;
                }
                serviceBase.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        #endregion
    }
}