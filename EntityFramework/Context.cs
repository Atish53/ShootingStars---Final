using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework
{
    class Context : DbContext
    {
        public DbSet<Student> Student { get; set; }

        private string DatabasePath { get; set; }

        public Context()
        {

        }

        public Context(string databasePath)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

    }
}
