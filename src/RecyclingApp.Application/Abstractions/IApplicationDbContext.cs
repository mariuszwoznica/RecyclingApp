using Microsoft.EntityFrameworkCore;
using RecyclingApp.Domain.Entities;
using RecyclingApp.Domain.Entities.Orders;
using RecyclingApp.Domain.Entities.Products;

namespace RecyclingApp.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Order> Orders { get; set; }
    DbSet<OrderItem> OrderItems { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<User> Users { get; set; }
}
