namespace WisdomClassroomApp.Models.Domain
{
    public class PersonCourse //MyCourses
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}