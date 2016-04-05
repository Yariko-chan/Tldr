using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Tldr.DomainClasses.Entities;

namespace Tldr.DomainClasses.Concrete
{
    public class CreativesDbContext : DbContext
    {
        public DbSet<Creative> Creatives { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bookmark>()
                .HasRequired(s => s.User)
                .WithMany(s => s.Bookmarks)
                .HasForeignKey(s => s.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasRequired(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .WillCascadeOnDelete(false);
        }

        public override int SaveChanges()
        {
            foreach (var stateinfo in this.ChangeTracker.Entries()
                .Where(e => e.Entity is StateInfo && e.State == EntityState.Added)
                .Select(e => e.Entity as StateInfo)
                )
            {
                stateinfo.CreateDate = DateTime.Now;
            }
            foreach (var stateinfo in this.ChangeTracker.Entries()
                .Where(e => e.Entity is StateInfo
                    && (e.State == EntityState.Modified || e.State == EntityState.Added)
                    )
                .Select(e => e.Entity as StateInfo)
                )
            {
                stateinfo.ModifyDate = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}
