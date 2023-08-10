using AutoMapper;
using RecyclingApp.Application.Filters;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Queries;
using RecyclingApp.Domain.Model;

namespace RecyclingApp.Application.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserDto>();
           

            CreateMap<GetAllUsersQuery, PaginationFilter>();

            CreateMap<GetAllUsersQuery, UserFilters>();
        }
    }
}
