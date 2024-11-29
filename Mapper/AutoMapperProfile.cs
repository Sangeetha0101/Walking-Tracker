using AutoMapper;
using IndiaWalks.Models.Domain;
using IndiaWalks.Models.DTO;

namespace IndiaWalks.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping from Region to RegionDTO and vice versa
            CreateMap<Region, RegionDTO>().ReverseMap();

            CreateMap<AddRegionDTORequest, Region>().ReverseMap();


            CreateMap<UpdateRegionDto, Region>().ReverseMap();

            CreateMap<AddWalkDTORequest, Walk>().ReverseMap();
            CreateMap<Walk,WalkDTO>().ReverseMap();
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
            CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();
        }
    }
}
