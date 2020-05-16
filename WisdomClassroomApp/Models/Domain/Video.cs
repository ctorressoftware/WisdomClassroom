namespace WisdomClassroomApp.Models.Domain
{
    public class Video
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}