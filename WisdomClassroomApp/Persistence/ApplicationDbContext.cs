using Microsoft.AspNet.Identity.EntityFramework;
using WisdomClassroomApp.Models.Identity;

namespace WisdomClassroomApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyDatabase", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}