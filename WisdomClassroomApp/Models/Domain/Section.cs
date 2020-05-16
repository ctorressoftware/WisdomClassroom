using System.Collections.Generic;

namespace WisdomClassroomApp.Models.Domain
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}