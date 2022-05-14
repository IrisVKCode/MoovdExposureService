using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Course : Entity
    {
        private readonly List<Step> _steps = new List<Step>();

        public Course(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyList<Step> Steps => _steps;
        public Theme Theme { get; private set; }
    }
}
