
using Activity26.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Activity26.Data
{
    public class AppDBcontext:DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(U => U.TaskItem).WithOne(T=>T.User).HasForeignKey(T=>T.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasOne(U =>U.Address).WithOne(T=>T.user).HasForeignKey<Address>(A=>A.userId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<TaskItem>().HasMany(T =>T.Checklist).WithOne(C =>C.Task).HasForeignKey(c=>c.TaskId).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }
}
