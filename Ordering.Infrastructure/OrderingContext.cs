using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.AggregateModels.OrderAggregate;

namespace Ordering.Infrastructure
{
    public class OrderingContext : DbContext, IUnitOfWork
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public OrderingContext(DbContextOptions<OrderingContext> options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
