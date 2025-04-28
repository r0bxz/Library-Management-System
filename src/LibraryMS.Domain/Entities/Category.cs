using System.Collections.Generic;
using LibraryMS.Books;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace LibraryMS.Categories
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }

        internal Category() { }

        public Category(string name, string description)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = Check.NotNullOrWhiteSpace(description, nameof(description));
            Books = new List<Book>();
        }

        public Category ChangeName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            return this;
        }

        public Category ChangeDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description));
            return this;
        }
    }
}
