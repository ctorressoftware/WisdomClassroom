namespace WisdomClassroomApp.Models.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasVideo { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        public int TypeActivityId { get; set; }
        public TypeActivity TypeActivity { get; set; }

        public Video Video { get; set; }

        //public virtual Video Video { get; set; } //Revisar si es necesario
    }
}