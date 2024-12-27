using Domain.Common;

namespace Application.Common.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
