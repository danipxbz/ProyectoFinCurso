using AutoMapper;
using AutoMapper.EquivalencyExpression;
using VLTMTool.Model.Model;
using VLTMTool.ViewModel;

namespace VLTMTool.Controller2.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VMtemp_vTechnicalUsers, temp_vTechnicalUsers>();
            CreateMap<VMTickets, Tickets>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket);
            CreateMap<VMTicketsAccessHistory, TicketsAccessHistory>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket && Origen.AccessDate == destino.AccessDate)
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());
            CreateMap<VMTicketsExceptionInfo, TicketsExceptionInfo>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket)
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());
            CreateMap<VMTicketsMessagesHistory, TicketsMessagesHistory>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket && Origen.MessageDate == destino.MessageDate)
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());
            CreateMap<VMTicketsStatusHistory, TicketsStatusHistory>()
                .EqualityComparison((Origen, destino) => Origen.IdTicket == destino.IdTicket && Origen.StatusDate == destino.StatusDate)
                .ForMember(dest => dest.Tickets, opt => opt.Ignore());
            CreateMap<VMTicketStatus, TicketStatus>();
            CreateMap<VMTicketTypes, TicketTypes>();
            CreateMap<VMvTickets, vTickets>();
            CreateMap<VMvTicketsStatusHistory, vTicketsStatusHistory>();
            CreateMap<VMvTHORApplications, vTHORApplications>();
            CreateMap<VMvTHORApplicationSections, vTHORApplicationSections>();
            CreateMap<VMvTHOREmployes, vTHOREmployes>();
        }
    }
}
