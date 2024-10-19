
using Activity26.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Activity26.Data
{
    public class AppDBcontext:DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }
      

    }
}
