using System;
using Framework.Domain;

namespace CollectionOfEntities.Model
{
    public class Step : Entity<long>
    {
        public string Title { get; private set; }
        public OrganizationLevel Level { get; private set; }
        public bool IsRequired { get; private set; }
        protected Step() { }
        public Step(long id, string title, OrganizationLevel level, bool isRequired) : base(id)
        {
            this.Title = title;
            this.Level = level;
            this.IsRequired = isRequired;
        }
    }
}