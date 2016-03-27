using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tldr.DataLayer;
using Tldr.DataLayer.Migrations;
using Tldr.DomainClasses;

namespace DBTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TldrContext, Configuration>());
            GetUsersNames();
            Console.ReadLine();
            //GetUsersName(3);
            //InsertUser();
            //UpdateUser();
            //InsertUser();
            //DeleteUser("Diana");
            //DeleteUsers("Diana");
            //AddUserWithCreative();
            //EagerLoading();
            //LoadWithProjection();
            //ExplicitLoading();
            //LazyLoading();
        }

        private static void LazyLoading()
        {
            using (var context = new TldrContext())
            {
                context.Configuration.LazyLoadingEnabled = true;
                var user = context.Users.Where(u => u.UserID == 34).First();
                Console.WriteLine("User {0} have {1} creatives", user.Name, user.Creatives.Count);
            }
        }

        private static void ExplicitLoading()
        {
            using (var context = new TldrContext())
            {
                var user = context.Users.Where(u => u.UserID == 34).First();
                context.Entry(user).Collection(c => c.Creatives).Load();
                Console.WriteLine("User {0} have {1} creatives", user.Name, user.Creatives.Count);
            }
        }

        private static void LoadWithProjection()
        {
            using (var context = new TldrContext())
            {
                var userCreativeGraph = context.Users
                    .Select(u => new { u, u.Creatives })
                    .ToList();
                var user = userCreativeGraph[0].u;

                var userWithCreative = context.Users
                    .Select(u => new
                    {
                        u,
                        FirstCrew = u.Creatives.FirstOrDefault()
                    })
                    .ToList();
            }
        }

        private static void EagerLoading()
        {
            using (var context = new TldrContext())
            {
                var eagerLoadGraph1 = context.Users.Include(u => u.Creatives).ToList();
                var eagerLoadGraph2 = context.Users.Include("Creatives").ToList();
                var eagerLoadGraph3 = context.Users.Include("Creatives.Parts").ToList();
                var eagerLoadGraph4 = context.Users
                    .Where(u => u.Creatives.Any())
                    .Include(u => u.Creatives.Select(c => c.Parts))
                    .ToList();
                var user = eagerLoadGraph4[0];
            }
        }

        private static void AddUserWithCreative()
        {
            var categories = GetCategories();
            var category = categories[1];

            var user = new User
            {
                Name = "Di",
                BirthDate = DateTime.Now.AddYears(-25),
            };
            var crew = new Creative
            {
                CreativeName = "Another one genius",
                Category = category,
                User = user
            };
            user.Creatives.Add(crew);

            using (var context = new TldrContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        private static List<Category> GetCategories()
        {
            using (var context = new TldrContext())
            {
                var category = new Category { CategoryName = "new" };
                context.Categories.Add(category);
                context.SaveChanges();
                return context.Categories.ToList<Category>();
            }
        }

        private static void DeleteUsers(string v)
        {
            using (var context = new TldrContext())
            {
                var users = context.Users.Where(c => c.Name == v).ToList();
                foreach (var user in users)
                {
                    context.Users.Remove(user);
                }
                context.SaveChanges();
            }
        }

        private static void DeleteUser(String name)
        {
            using (var context = new TldrContext())
            {
                var user = context.Users.FirstOrDefault(c => c.Name == name);
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        private static void UpdateUser()
        {
            using (var context = new TldrContext())
            {
                var user = context.Users.FirstOrDefault(c => c.Name == "Diana");
                user.BirthDate = DateTime.Now.AddYears(-25);
                context.SaveChanges();

                GetUser(user.UserID);
            }
        }

        private static void InsertUser()
        {
            var user = new User { Name = "Diana", BirthDate = DateTime.Now };
            using (var context = new TldrContext())
            {
                context.Users.Add(user);
                context.SaveChanges();

                GetUser(user.UserID);
            }
        }

        private static void GetUser(int v)
        {
            using (var context = new TldrContext())
            {
                var user = context.Users.Find(v);
                Console.WriteLine(user.Name);
                Console.WriteLine(user.BirthDate);
            }
        }

        private static void GetUsersNames()
        {
            using (var context = new TldrContext())
            {
                foreach (var user in context.Users)
                {
                    Console.WriteLine("{0} - {1} - {2}", user.Name, user.CreateDate, user.ModifyDate);
                }
            }
        }
    }
}
