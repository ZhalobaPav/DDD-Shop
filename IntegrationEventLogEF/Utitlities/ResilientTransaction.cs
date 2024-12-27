using Microsoft.EntityFrameworkCore;

namespace IntegrationEventLogEF.Utitlities
{
    public class ResilientTransaction
    {
        private DbContext _context;
        private ResilientTransaction(DbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));
        public static ResilientTransaction New(DbContext dbContext) => new(dbContext);

        public async Task ExecuteAsync(Func<Task> action)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                await action();
                await transaction.CommitAsync();
            });
        }
    }
}
