using System.Collections.Generic;

namespace WisdomClassroomApp.Models.Domain
{
    public class TypeActivity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}