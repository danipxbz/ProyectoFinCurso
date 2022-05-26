using AutoMapper;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLTMTool.Model.Model;
using VLTMTool.Model.Services;
using VLTMTool.ViewModel;

namespace VLTMTool.Controller2.Controllers
{
    public class TicketGestionController : ControllerBase
    {
        public TicketGestionController(ServiceBDBase controllerBase, IMapper mapper) : base(controllerBase, mapper)
        {
        }

        #region Domain to ViewModel
        public List<VMTickets> GetAllTickets()
        {
            try
            {
                List<Tickets> listTickets = serviceBase.DbContext.Tickets.ToList();
                List<VMTickets> VMlistTickets = new List<VMTickets>();
                mapper.Map(listTickets, VMlistTickets, typeof(List<Tickets>), typeof(List<VMTickets>));
                return VMlistTickets;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        public List<VMTicketStatus> GetAllStatus()
        {
            try
            {
                List<TicketStatus> listStatus = serviceBase.DbContext.TicketStatus.ToList();
                List<VMTicketStatus> VMlistStatus = new List<VMTicketStatus>();
                mapper.Map(listStatus, VMlistStatus, typeof(List<TicketStatus>), typeof(List<VMTicketStatus>));
                return VMlistStatus;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        public List<VMTicketsMessagesHistory> GetMessageHistory()
        {
            List<TicketsMessagesHistory> listMessageHistory = serviceBase.DbContext.TicketsMessagesHistory.ToList();
            List<VMTicketsMessagesHistory> listVMMessageHistory = new List<VMTicketsMessagesHistory>();
            mapper.Map(listMessageHistory, listVMMessageHistory, typeof(List<TicketsMessagesHistory>), typeof(List<VMTicketsMessagesHistory>));
            return listVMMessageHistory;
        }
        public DateTime GetLastAccess(int idTicket)
        {
            DateTime lastAccess = DateTime.Now;
            List<TicketsAccessHistory> listAccessHistory = serviceBase.DbContext.TicketsAccessHistory.ToList();
            List<VMTicketsAccessHistory> listVMAccessHistory = new List<VMTicketsAccessHistory>();
            mapper.Map(listAccessHistory, listVMAccessHistory, typeof(List<TicketsAccessHistory>), typeof(List<VMTicketsAccessHistory>));
            if (listVMAccessHistory.OrderByDescending(x => x.AccessDate).Where(x => x.User == LoginInfo.UserName && x.IdTicket == idTicket).Select(x => x.AccessDate).Any())
                lastAccess = listVMAccessHistory.OrderByDescending(x => x.AccessDate).Where(x => x.User == LoginInfo.UserName && x.IdTicket == idTicket).Select(x => x.AccessDate).First();
            return lastAccess;
        }
        #endregion
        public List<VMvTickets> LoadTickets(ExpressionStarter<VMvTickets> predicate)
        {
            try
            {
                log.Info("Creando vista con los filtros aplicados.");
                List<vTickets> listTickets = serviceBase.DbContext.vTickets.AsNoTracking().ToList();
                serviceBase.DbContext.ChangeTracker.DetectChanges();
                List<VMvTickets> listFilterTickets = new List<VMvTickets>();
                mapper.Map(listTickets, listFilterTickets, typeof(List<vTickets>), typeof(List<VMvTickets>));
                if (predicate.IsStarted)
                    listFilterTickets = listFilterTickets.Where(predicate).ToList();

                return listFilterTickets;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
    }
}
