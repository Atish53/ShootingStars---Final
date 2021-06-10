using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework
{
    class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Query> Queries { get; set; }

        private string DatabasePath { get; set; }

        public Context()
        {

        }

        public Context(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
