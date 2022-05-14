using System.Collections.Generic;

namespace Domain.Models
{
    public class Category : Entity
    {
        private readonly List<Tag> _tags = new List<Tag>();

        public Category(string name, int subCategoryId)
        {
            Name = name;
            SubCategoryId = subCategoryId;
        }

        public string Name { get; private set; }
        public Category SubCategory { get; private set; }
        public int SubCategoryId { get; private set; }
        public IReadOnlyList<Tag> Tags => _tags;
    }
}