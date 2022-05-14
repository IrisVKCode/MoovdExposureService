using System;
namespace Domain.Models
{
    public class Theme
    {
        public Theme()
        {
        }

        public string Name { get; private set; }
        public string PrimaryColor { get; private set; }
        public string SecondaryColor { get; private set; }
    }
}
