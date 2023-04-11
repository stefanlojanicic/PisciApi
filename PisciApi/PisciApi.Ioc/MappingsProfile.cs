using ApiModels.Entities;
using AutoMapper;
using Db.MainDatabase;

namespace PisciApi.Ioc
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() {
            CreateMap<Pisci, PisacDto>();
        }
    }
}
