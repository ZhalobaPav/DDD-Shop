﻿using MediatR;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        int? _requestedHashCode;
        int _Id;
        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        public bool IsTransient()
        {
            return this.Id == default;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is BaseEntity))
                return false;
            if(Object.ReferenceEquals(this, obj)) 
                return true;
            if(this.GetType() != obj.GetType()) 
                return false;
            BaseEntity item = (BaseEntity)obj;
            if(item.IsTransient() || this.IsTransient())
                return false;
            else
               return item.Id == this.Id;
        }
        public override int GetHashCode()
        {
            if(!IsTransient())
            {
                if (!_requestedHashCode.HasValue) 
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;
                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }
        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            if(Object.Equals(left, null))
                return Object.Equals(right, null)?true:false;
            else
                return left.Equals(right);
        }
        public static bool operator !=(BaseEntity left, BaseEntity right) 
        {
            return !(left == right);
        }
    }
}
