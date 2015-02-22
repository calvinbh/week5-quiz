using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week5_quiz2.Data.Model;
using System.Data.Entity.Migrations;


namespace week5_quiz2.Data
{
    public class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool roles = false, bool users = false, bool questions = false, bool quizoptions = false, bool answer = false)
        {
            if (roles) SeedRoles(db);
            if (users) SeedUsers(db);
            if (questions) SeedQuestions(db);
            if (quizoptions) SeedQuizOptions(db);
            if (answer) SeedAnswers(db);
        }

        private static void SeedQuestions(ApplicationDbContext db)
        {
            db.Questions.AddOrUpdate(x => x.Title,
                new Question() { Title = "", QuizOptions =  "" , QuestionId = 1 },
                );
        }

        private static void SeedQuizOptions(ApplicationDbContext db)
        {

        }

        private static void SeedAnswers(ApplicationDbContext db)
        {

        }

        private static void SeedRoles(ApplicationDbContext db)
        {
            var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);

            if (!db.Roles.Any(x => x.Name == Role.USER))
            {
                manager.Create(new IdentityRole() { Name = Role.USER });
            }
            if (!manager.RoleExists(Role.ADMIN))
            {
                manager.Create(new IdentityRole() { Name = Role.ADMIN });
            }
        }

        private static void SeedUsers(ApplicationDbContext db)
        {
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store);

            if (!db.Users.Any(x => x.Email == "Test@Test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "Test@Test.com",
                    UserName = "Test@Test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, Role.USER);
            }

            if (!db.Users.Any(x => x.Email == "Admin@Test.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "Admin@Test.com",
                    UserName = "Admin@Test.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, Role.ADMIN);
            }
        }
    }
}
