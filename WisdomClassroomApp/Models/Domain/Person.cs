using System;
using System.Collections.Generic;

namespace WisdomClassroomApp.Models.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<PersonCourse> MyCourses { get; set; }
    }
}