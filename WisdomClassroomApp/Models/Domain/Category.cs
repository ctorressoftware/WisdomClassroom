using System.Collections.Generic;

namespace WisdomClassroomApp.Models.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}