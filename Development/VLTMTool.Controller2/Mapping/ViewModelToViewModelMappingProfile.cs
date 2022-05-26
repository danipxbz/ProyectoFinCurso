using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLTMTool.Model.Model;
using VLTMTool.ViewModel;

namespace VLTMTool.Controller2.Mapping
{
    public class ViewModelToViewModelMappingProfile : Profile
    {
        public ViewModelToViewModelMappingProfile()
        {
            CreateMap<VMtemp_vTechnicalUsers, VMtemp_vTechnicalUsers>();
            CreateMap<VMTickets, VMTickets>();
            CreateMap<VMTicketsAccessHistory, VMTicketsAccessHistory>();
            CreateMap<VMTicketsExceptionInfo, VMTicketsExceptionInfo>();
            CreateMap<VMTicketsMessagesHistory, VMTicketsMessagesHistory>();
            CreateMap<VMTicketsStatusHistory, VMTicketsStatusHistory>();
            CreateMap<VMTicketStatus, VMTicketStatus>();
            CreateMap<VMTicketTypes, VMTicketTypes>();
            CreateMap<VMvTickets, VMvTickets>();
            CreateMap<VMvTicketsStatusHistory, VMvTicketsStatusHistory>();
            CreateMap<VMvTHORApplications, VMvTHORApplications>();
            CreateMap<VMvTHORApplicationSections, VMvTHORApplicationSections>();
            CreateMap<VMvTHOREmployes, VMvTHOREmployes>();
        }
    }
}
