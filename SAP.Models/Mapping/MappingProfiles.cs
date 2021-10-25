using AutoMapper;
using SAP.Models.DTOs.Request.Transactions;
using SAP.Persistence.Models;

namespace SAP.Models.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SapInterfaceModel, SapInterfaceTransaction>().ReverseMap();
        }
    }
}
