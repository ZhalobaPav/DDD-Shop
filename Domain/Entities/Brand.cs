using Domain.Common;

namespace Domain.Entities
{
    public class Brand:BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }
        public Brand(string title)
        {
            Title = title;
        }
        public Brand()
        { }
    }
}
