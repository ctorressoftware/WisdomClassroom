using System;
using System.Collections.Generic;

namespace WisdomClassroomApp.Models.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Requirements { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<PersonCourse> Students { get; set; }
    }
}