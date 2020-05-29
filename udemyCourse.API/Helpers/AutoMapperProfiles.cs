using System.Linq;
using AutoMapper;
using udemyCourse.API.Dtos;
using udemyCourse.API.Models;

namespace udemyCourse.API.Helpers
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
              // for a specific user
            CreateMap<User, UserForListDto>()
          // We define a photo urlproperty
            .ForMember(dest => dest.PhotoUrl, opt => 
            // Where the info is gathered from
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailedDto>()
             // We define a photo urlproperty
            .ForMember(dest => dest.PhotoUrl, opt => 
            // Where the info is gathered from
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                // calculating age from date of birth till today
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
        }
    }
}