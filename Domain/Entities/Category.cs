using Domain.Common;

namespace Domain.Entities
{
    public class Category:BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }
        public Category(string title)
        {
            Title = title;
        }
#pragma warning disable CS8618
        public Category()
        {}
    }
}
