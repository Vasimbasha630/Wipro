
using AutoMapper;
using HotelBookingApi.DTOs;
using HotelBookingApi.Models;
using HotelProject.DTOs;

namespace HotelBookingApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Room, RoomDto>();
            CreateMap<Booking, BookingDto>();
        }
    }
}
