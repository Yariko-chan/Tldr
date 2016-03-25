using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tldr.DataLayer;
using Tldr.Models;

namespace DBTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            GetUsersNames();
        }

        private static void GetUsersNames()
        {
            using (var context = new TldrContext())
            {
                context.Users.Add(new User { Name = "Julie", BirthDate = DateTime.Now });
                context.Users.Add(new User { Name = "Lilian", BirthDate = DateTime.Now });
                context.Users.Add(new User { Name = "Kyra", BirthDate = DateTime.Now });

                

                context.SaveChanges();

                var users = context.Users.ToList();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }
    }
}
