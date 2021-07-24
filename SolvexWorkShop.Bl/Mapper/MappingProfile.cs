using AutoMapper;
using SolvexWorkshop.Model.Entities;
using SolvexWorkShop.Bl.Dto;

namespace GenericApi.Bl.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Document, DocumentDto>().ReverseMap();

            CreateMap<User, UserDto>()
                .ForMember(dto => dto.PhotoFileName, config => config.MapFrom(entity => entity.Photo.FileName));
            CreateMap<UserDto, User>();

            CreateMap<WorkShop, WorkShopDto>().ReverseMap();

            CreateMap<WorkShopMember, WorkShopMemberDto>().ReverseMap();

            CreateMap<WorkShopDay, WorkShopDayDto>().ReverseMap();
        }
    }
}