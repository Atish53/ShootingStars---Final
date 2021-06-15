using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework
{
    public class Planner
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
