using LoginPage.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginPage.DataAccess
{
    public class LoginPageDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=GVY792; Database=LoginPageDb; Integrated Security=SSPI; persist security info=True;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
