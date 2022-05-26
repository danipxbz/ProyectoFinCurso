using AutoMapper;
using AutoMapper.EquivalencyExpression;
using VLTMTool.Model.Model;
using VLTMTool.ViewModel;

namespace VLTMTool.Controller2.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<temp_vTechnicalUsers, VMtemp_vTechnicalUsers>();
            CreateMap<Tickets, VMTickets>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket);
            CreateMap<TicketsAccessHistory, VMTicketsAccessHistory>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket && Origen.AccessDate == destino.AccessDate);
            CreateMap<TicketsExceptionInfo, VMTicketsExceptionInfo>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket);
            CreateMap<TicketsMessagesHistory, VMTicketsMessagesHistory>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket && Origen.MessageDate == destino.MessageDate);
            CreateMap<TicketsStatusHistory, VMTicketsStatusHistory>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket && Origen.StatusDate == destino.StatusDate)
                .ForMember(dest => dest.StatusName, origen => origen.MapFrom(o => o.TicketStatus.StatusName));
            CreateMap<TicketStatus, VMTicketStatus>();
            CreateMap<TicketTypes, VMTicketTypes>();
            CreateMap<vTickets, VMvTickets>();
            CreateMap<vTicketsStatusHistory, VMvTicketsStatusHistory>();
            CreateMap<vTHORApplications, VMvTHORApplications>();
            CreateMap<vTHORApplicationSections, VMvTHORApplicationSections>();
            CreateMap<vTHOREmployes, VMvTHOREmployes>();
        }
    }
}
