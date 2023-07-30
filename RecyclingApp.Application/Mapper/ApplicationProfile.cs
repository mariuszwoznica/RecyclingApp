using AutoMapper;
using RecyclingApp.Application.Filters;
using RecyclingApp.Application.Models;
using RecyclingApp.Application.Orders.Queries;
using RecyclingApp.Application.Queries;
using RecyclingApp.Domain.Model;
using RecyclingApp.Domain.Model.Orders;

namespace RecyclingApp.Application.Mapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<OrderItem, OrderItemDto>();

            CreateMap<Order, OrderCreatedDto>();

            CreateMap<GetAllUsersQuery, PaginationFilter>();
            CreateMap<GetAllOrdersQuery, PaginationFilter>();
            CreateMap<GetAllProductsQuery, PaginationFilter>();

            CreateMap<GetAllUsersQuery, UserFilters>();
            CreateMap<GetAllOrdersQuery, OrderFilters>();
            CreateMap<GetAllProductsQuery, ProductFilters>();
        }
    }
}
