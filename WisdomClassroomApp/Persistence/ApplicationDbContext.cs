using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WisdomClassroomApp.Models.Domain;
using WisdomClassroomApp.Models.Identity;

namespace WisdomClassroomApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyDatabase", throwIfV1Schema: false)
        {
        }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonCourse> PersonCourse { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<TypeActivity> TypeActivity { get; set; }
        public DbSet<Video> Video { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Identity Tables

            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            #endregion

            #region TypeActivity

            modelBuilder.Entity<TypeActivity>().ToTable("TypeActivity");

            modelBuilder.Entity<TypeActivity>().HasKey(x => x.Id);

            modelBuilder.Entity<TypeActivity>().Property(x => x.Description)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsRequired();
            #endregion

            #region Category

            modelBuilder.Entity<Category>().ToTable("Category");

            modelBuilder.Entity<Category>().HasKey(x => x.Id);

            modelBuilder.Entity<Category>().Property(x => x.Description)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsRequired();
            #endregion

            #region Person

            modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<Person>().HasKey(x => x.Id);

            modelBuilder.Entity<Person>().Property(x => x.Birthday)
                        .IsOptional();

            modelBuilder.Entity<Person>().Property(x => x.Name)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Person>().Property(x => x.LastName)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Person>().Property(x => x.Email)
                        .HasColumnType("varchar")
                        .HasMaxLength(150)
                        .IsRequired();

            modelBuilder.Entity<Person>().Property(x => x.Role)
                        .HasColumnType("varchar")
                        .HasMaxLength(10)
                        .IsRequired();
            #endregion

            #region Course

            modelBuilder.Entity<Course>().ToTable("Course");

            modelBuilder.Entity<Course>().HasKey(x => x.Id);

            modelBuilder.Entity<Course>().Property(x => x.Description)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Course>().Property(x => x.CreationDate)
                        .IsRequired();

            //Configuring Foreign Keys

            modelBuilder.Entity<Course>()
                        .HasRequired(x => x.Category)
                        .WithMany(x => x.Courses)
                        .HasForeignKey(x => x.CategoryId);
            #endregion

            #region PersonCourse

            modelBuilder.Entity<PersonCourse>().ToTable("PersonCourse");

            modelBuilder.Entity<PersonCourse>().HasKey(x => x.Id);

            //Configuring Foreign Keys

            modelBuilder.Entity<PersonCourse>()
                        .HasRequired(x => x.Person)
                        .WithMany(x => x.MyCourses)
                        .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<PersonCourse>()
                        .HasRequired(x => x.Course)
                        .WithMany(x => x.Students)
                        .HasForeignKey(x => x.CourseId);
            #endregion

            #region Section

            modelBuilder.Entity<Section>().ToTable("Section");

            modelBuilder.Entity<Section>().HasKey(x => x.Id);

            modelBuilder.Entity<Section>().Property(x => x.Title)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Section>().Property(x => x.Description)
                        .HasColumnType("varchar")
                        .HasMaxLength(200)
                        .IsRequired();

            //Configuring Foreign Keys

            modelBuilder.Entity<Section>()
                        .HasRequired(x => x.Course)
                        .WithMany(x => x.Sections)
                        .HasForeignKey(x => x.CourseId);
            #endregion

            #region Activity

            modelBuilder.Entity<Activity>().ToTable("Activity");

            modelBuilder.Entity<Activity>().HasKey(x => x.Id);

            modelBuilder.Entity<Activity>().Property(x => x.Title)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Activity>().Property(x => x.Description)
                        .HasColumnType("varchar")
                        .HasMaxLength(2000)
                        .IsRequired();

            modelBuilder.Entity<Activity>().Property(x => x.HasVideo)
                        .HasColumnType("bit")
                        .IsRequired();

            //Configuring Foreign Keys

            modelBuilder.Entity<Activity>()
                        .HasRequired(x => x.Section)
                        .WithMany(x => x.Activities)
                        .HasForeignKey(x=>x.SectionId);

            modelBuilder.Entity<Activity>()
                        .HasRequired(x => x.TypeActivity)
                        .WithMany(x => x.Activities)
                        .HasForeignKey(x => x.TypeActivityId);
            #endregion

            #region Video

            modelBuilder.Entity<Video>().ToTable("Video");

            modelBuilder.Entity<Video>().HasKey(x => x.Id);

            modelBuilder.Entity<Video>().Property(x => x.Path)
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsRequired();

            //Configuring Foreign Keys

            modelBuilder.Entity<Video>()
                        .HasRequired(p => p.Activity)
                        .WithOptional(b => b.Video);
            #endregion
        }
    }
}