using AutoMapper;
using Posts.Example.DBLayer.Models;
using Posts.Example.Models.Dtos.Posts;

namespace Posts.Example.Utilities.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreatePostDto, Post>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdatePostDto, Post>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<PostDto, Post>().ReverseMap();
    }
}
