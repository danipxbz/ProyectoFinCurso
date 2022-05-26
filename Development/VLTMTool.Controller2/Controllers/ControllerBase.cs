using AutoMapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using VLTMTool.Model.Infrastructure;
using VLTMTool.Model.Model;
using VLTMTool.Model.Services;
using VLTMTool.ViewModel;

namespace VLTMTool.Controller2.Controllers
{
    public class ControllerBase
    {
        internal ServiceBDBase serviceBase;
        internal IMapper mapper;
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IncidenceNotifications NotNewInc;

        public ControllerBase(ServiceBDBase controllerBase, IMapper mapper)
        {
            serviceBase = controllerBase;
            this.mapper = mapper;
        }
        public List<string> GetEmailTechnic(List<string> Employees)
        {
            List<string> emails = new List<string>();
            try
            {
                List<vTHOREmployes> listEmployes = serviceBase.DbContext.vTHOREmployes.ToList();
                List<VMvTHOREmployes> VMlistEmployes = new List<VMvTHOREmployes>();
                mapper.Map(listEmployes, VMlistEmployes, typeof(List<vTHOREmployes>), typeof(List<VMvTHOREmployes>));
                foreach (string employee in Employees)
                {
                    emails.Add(VMlistEmployes.Where(x => x.EmployeeCode == employee).Select(x => x.Email).First());
                }
                return emails;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        public List<VMtemp_vTechnicalUsers> GetAllTechnicals()
        {
            try
            {
                List<temp_vTechnicalUsers> listTechnicals = serviceBase.DbContext.temp_vTechnicalUsers.ToList();
                List<VMtemp_vTechnicalUsers> VMlistTechnicals = new List<VMtemp_vTechnicalUsers>();
                mapper.Map(listTechnicals, VMlistTechnicals, typeof(List<temp_vTechnicalUsers>), typeof(List<VMtemp_vTechnicalUsers>));
                return VMlistTechnicals;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        public List<VMTicketTypes> GetAllTicketsTypes()
        {
            try
            {
                List<TicketTypes> listTypes = serviceBase.DbContext.TicketTypes.ToList();
                List<VMTicketTypes> VMlistTypes = new List<VMTicketTypes>();
                mapper.Map(listTypes, VMlistTypes, typeof(List<TicketTypes>), typeof(List<VMTicketTypes>));
                return VMlistTypes;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        public void SaveTicket(VMTickets newTicket)
        {
            try
            {
                Tickets ticket = serviceBase.DbContext.Tickets.Where(x => x.IdTicket == newTicket.IdTicket).FirstOrDefault();

                if (ticket != null)
                {
                    mapper.Map(newTicket, ticket, typeof(VMTickets), typeof(Tickets));
                    serviceBase.DbContext.Tickets.AddOrUpdate(ticket);
                }
                else
                {
                    ticket = new Tickets();
                    mapper.Map(newTicket, ticket, typeof(VMTickets), typeof(Tickets));
                    serviceBase.DbContext.Entry(ticket).State = EntityState.Added;
                }
                serviceBase.DbContext.SaveChanges();
                //Creo un nuevo estado como pendiente
                if (newTicket.IdTicket <= 0)
                {
                    newTicket.IdTicket = ticket.IdTicket;
                    CreateTicketStatus(newTicket, Constants.STATUS_PENDING_ID, Constants.STATUS_PENDING_NAME);
                    SaveTicket(newTicket);
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        public void CreateTicketAccess(VMTickets Ticket, string User, string access)
        {
            VMTicketsAccessHistory TicketAccess = new VMTicketsAccessHistory()
            {
                IdTicket = Ticket.IdTicket,
                AccessDate = DateTime.Now,
                User = User,
                AccessActivity = access
            };
            Ticket.TicketsAccessHistory.Add(TicketAccess);
            SaveTicketAccess(TicketAccess);
        }
        public void SaveTicketAccess(VMTicketsAccessHistory newTicket)
        {
            try
            {
                TicketsAccessHistory ticketAccess = serviceBase.DbContext.TicketsAccessHistory.Where(x => x.IdTicket == newTicket.IdTicket && x.AccessDate == newTicket.AccessDate).FirstOrDefault();

                if (ticketAccess != null)
                {
                    serviceBase.DbContext.TicketsAccessHistory.AddOrUpdate(ticketAccess);
                }
                else
                {
                    ticketAccess = new TicketsAccessHistory();
                    mapper.Map(newTicket, ticketAccess, typeof(VMTicketsAccessHistory), typeof(TicketsAccessHistory));
                    serviceBase.DbContext.Entry(ticketAccess).State = EntityState.Added;
                }
                serviceBase.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }
        public void CreateTicketStatus(VMTickets Ticket ,int idStatus, string statusName, string resolvedVersion = null, double? timeUsed = null)
        {
            CreateTicketAccess(Ticket, LoginInfo.UserName, "Change status");
            VMTicketsStatusHistory TicketStatus = new VMTicketsStatusHistory()
            {
                IdTicket = Ticket.IdTicket,
                StatusDate = DateTime.Now,
                IdStatus = idStatus,
                StatusName = statusName,
                User = LoginInfo.UserName,
                AsignedTo = Ticket.AsignedTo,
                ResolvedVersion = resolvedVersion,
                TimeForResolved = timeUsed
            };
            Ticket.TicketsStatusHistory.Add(TicketStatus);
        }
        public List<VMvTHORApplications> GetAllTHORApplications()
        {
            try
            {
                List<vTHORApplications> listTHORApplications = serviceBase.DbContext.vTHORApplications.ToList();
                List<VMvTHORApplications> VMlistTHORApplications = new List<VMvTHORApplications>();
                mapper.Map(listTHORApplications, VMlistTHORApplications, typeof(List<vTHORApplications>), typeof(List<VMvTHORApplications>));
                return VMlistTHORApplications;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        public List<VMvTHORApplicationSections> GetAllTHORApplicationSections()
        {
            try
            {
                List<vTHORApplicationSections> listTHORApplicationsModules = serviceBase.DbContext.vTHORApplicationSections.ToList();
                List<VMvTHORApplicationSections> VMlistTHORApplicationsModules = new List<VMvTHORApplicationSections>();
                mapper.Map(listTHORApplicationsModules, VMlistTHORApplicationsModules, typeof(List<vTHORApplicationSections>), typeof(List<VMvTHORApplicationSections>));
                return VMlistTHORApplicationsModules;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }
        }
        public void NotifyEmail(VMTickets newTicket)
        {
            NotNewInc = new IncidenceNotifications(newTicket);
            List <string> NotifyUsers = new List <string>();
            
            switch (newTicket.TicketsStatusHistory.OrderByDescending(x => x.StatusDate).Select(x => x.IdStatus).First())
            {
                case Constants.STATUS_PENDING_ID:
                    NotifyUsers = GetAllTechnicals().Where(x => x.TechnicalUser.ToLower() != "rperez").Select(x => x.TechnicalUser).ToList();
                    if (newTicket.TicketsStatusHistory.Count == 1)
                    {
                        NotNewInc.subject = "New Incidence";
                        NotNewInc.body = newTicket.User + " has reported a new incidence.\n\n" + newTicket.Comment;
                    }
                    else
                    {
                        string lastChangeStatus = newTicket.TicketsStatusHistory.OrderByDescending(x => x.StatusDate).Where(x => x.User != null).Select(x => x.User).ToString();
                        NotNewInc.subject = "Unresolved Incidence";
                        NotNewInc.body =  lastChangeStatus + " has put the incidence number " + newTicket.IdTicket + " pending again.";
                        NotifyUsers.Add(newTicket.User);
                    }
                    break;
                case Constants.STATUS_ASSIGN_ID:
                    NotNewInc.subject = "Assigned Incidence";
                    NotNewInc.body = "The incidence number " + newTicket.IdTicket + " has been assigned to a technician";
                    NotifyUsers.Add(GetAllTechnicals().Where(x => x.IdTechnical == newTicket.AsignedTo).Select(x => x.TechnicalUser).First());
                    NotifyUsers.Add(newTicket.User);
                    break;
                case Constants.STATUS_RESOLVE_VERSION_ID:
                    string userResolve = GetAllTechnicals().Where(x => x.IdTechnical == newTicket.AsignedTo).Select(x => x.TechnicalUser).First();
                    NotNewInc.subject = "Resolved Incidence";
                    NotNewInc.body = userResolve + " has resolved the incidence number " + newTicket.IdTicket + " and is pending validation.";
                    NotifyUsers.Add(newTicket.User);
                    break;
                case Constants.STATUS_RESOLVE_VALIDATION_ID:
                    NotNewInc.subject = "Validated Incidence";
                    NotNewInc.body = newTicket.User + " has validated the incidence number " + newTicket.IdTicket;
                    NotifyUsers.Add(GetAllTechnicals().Where(x => x.IdTechnical == newTicket.AsignedTo).Select(x => x.TechnicalUser).First());
                    break;
                case Constants.STATUS_CLOSE_ID:
                    NotNewInc.subject = "Incidence closed";
                    NotNewInc.body = "The incidence number " + newTicket.IdTicket + " has been resolved correctly and is now closed.";
                    NotifyUsers.Add(GetAllTechnicals().Where(x => x.IdTechnical == newTicket.AsignedTo).Select(x => x.TechnicalUser).First());
                    NotifyUsers.Add(newTicket.User);
                    break;
            }
            NotifyUsers.Add(Constants.TECHNIC_ADMIN);
            NotNewInc.Emails = GetEmailTechnic(NotifyUsers);


            Thread th = new Thread(new ThreadStart(NotNewInc.SendNotify));

            th.Start();
        }
    }
}
