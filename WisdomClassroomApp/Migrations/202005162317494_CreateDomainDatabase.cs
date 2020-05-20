namespace WisdomClassroomApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateDomainDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "Role");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "UserRole");
            RenameTable(name: "dbo.AspNetUsers", newName: "User");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "UserClaim");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "UserLogin");
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(nullable: false, maxLength: 2000, unicode: false),
                        HasVideo = c.Boolean(nullable: false),
                        SectionId = c.Int(nullable: false),
                        TypeActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Section", t => t.SectionId, cascadeDelete: true)
                .ForeignKey("dbo.TypeActivity", t => t.TypeActivityId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.TypeActivityId);
            
            CreateTable(
                "dbo.Section",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(nullable: false, maxLength: 200, unicode: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Requirements = c.String(),
                        Description = c.String(nullable: false, maxLength: 100, unicode: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonCourse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Birthday = c.DateTime(),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Role = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeActivity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Path = c.String(nullable: false, maxLength: 100, unicode: false),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activity", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Video", "Id", "dbo.Activity");
            DropForeignKey("dbo.Activity", "TypeActivityId", "dbo.TypeActivity");
            DropForeignKey("dbo.Activity", "SectionId", "dbo.Section");
            DropForeignKey("dbo.Section", "CourseId", "dbo.Course");
            DropForeignKey("dbo.PersonCourse", "PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "CategoryId", "dbo.Category");
            DropIndex("dbo.Video", new[] { "Id" });
            DropIndex("dbo.PersonCourse", new[] { "CourseId" });
            DropIndex("dbo.PersonCourse", new[] { "PersonId" });
            DropIndex("dbo.Course", new[] { "CategoryId" });
            DropIndex("dbo.Section", new[] { "CourseId" });
            DropIndex("dbo.Activity", new[] { "TypeActivityId" });
            DropIndex("dbo.Activity", new[] { "SectionId" });
            DropTable("dbo.Video");
            DropTable("dbo.TypeActivity");
            DropTable("dbo.Person");
            DropTable("dbo.PersonCourse");
            DropTable("dbo.Category");
            DropTable("dbo.Course");
            DropTable("dbo.Section");
            DropTable("dbo.Activity");
            RenameTable(name: "dbo.UserLogin", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.UserClaim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.User", newName: "AspNetUsers");
            RenameTable(name: "dbo.UserRole", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Role", newName: "AspNetRoles");
        }
    }
}
