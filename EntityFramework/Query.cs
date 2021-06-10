using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EntityFramework
{
    public class Query
    {
        [PrimaryKey, AutoIncrement]
        public int QueryID { get; set; }
        
        [ForeignKey(typeof(Student))]
        public int StudentID { get; set; }

        public string Message { get; set; }

        public string Response { get; set; }

        public bool Status { get; set; }
    }
}
