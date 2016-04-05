using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tldr.DomainClasses;
using System.Data.Entity;
using Tldr.DomainClasses.Entities;

namespace Tldr.DataLayer
{
    class UserDataAccess
    {
        readonly TldrContext _context = new TldrContext();

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void DeleteUserById(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
