using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Video : Entity
    {
        private readonly List<Category> _categories = new List<Category>();
        private readonly List<Tag> _tags = new List<Tag>();

        public Video(string name, string description, string videoLocation,
            string thumbNailLocation, string approvedBy)
        {
            Name = name;
            Description = description;
            VideoLocation = videoLocation;
            ThumbnailLocation = thumbNailLocation;
            ApprovedBy = approvedBy;
            InsertTime = DateTime.Now;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime InsertTime { get; private set; }
        public string VideoLocation { get; private set; }
        public string ThumbnailLocation { get; private set; }
        public string ApprovedBy { get; private set; }
        public DateTime DeleteTime { get; private set; }
        public IReadOnlyList<Category> Categories => _categories;
        public IReadOnlyList<Tag> Tags => _tags;

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }
    }
}
