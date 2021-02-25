using System;
using System.Collections.Generic;

namespace Framework.Domain
{
    public abstract class Entity<TKey> : IEquatable<Entity<TKey>>
    {
        public TKey Id { get; protected set; }
        protected Entity() { }
        protected Entity(TKey id)
        {
            Id = id;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity<TKey>) obj);
        }
        public override int GetHashCode()
        {
            return EqualityComparer<TKey>.Default.GetHashCode(Id);
        }
        public bool Equals(Entity<TKey> other)
        {
            if (other == null) return false;
            return this.Id.Equals(other.Id);
        }
    }
}
