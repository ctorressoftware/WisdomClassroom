namespace WisdomClassroomApp.Migrations
{
    using System.Data.Entity.Migrations;
    using WisdomClassroomApp.Persistence;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {

        }
    }
}
