using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Company : Entity
    {
        private readonly List<Category> _categories = new List<Category>();

        public Company()
        {
        }

        public string Name { get; private set; }
        public DateTime InsertTime { get; private set; }
        public DateTime DeleteTime { get; private set; }
        public IReadOnlyList<Category> Categories => _categories;
    }
}
