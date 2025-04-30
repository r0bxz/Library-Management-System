using System.Collections.Generic;
using LibraryMS.Books;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace LibraryMS.Categories
{
    public class Category : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }

        internal Category() { }

        public Category(string name, string description)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
            Books = new List<Book>();
        }

        public Category ChangeName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            return this;
        }

        public Category ChangeDescription(string description)
        {
            Description = description;
            return this;
        }
    }
}
