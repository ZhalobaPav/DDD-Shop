using Application.Common.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Common;

namespace Infrastructure.Data
{
    public class EFRepository<T>:RepositoryBase<T>, IReadRepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EFRepository(CatalogContext context) : base(context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        private readonly CatalogContext _context;

        public IUnitOfWork UnitOfWork => _context;
    }
}
    