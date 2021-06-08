using SQLite;
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public string StudentEmail { get; set; }

        public string StudentPassword { get; set; }

        public string StudentPhone { get; set; }

        public string StudentAddress { get; set; }

        public override string ToString()
        {
            return string.Format($"{StudentName}" + "\n" + $"{StudentEmail}" + "\n" + $"{StudentPassword}" + "\n" + $"{StudentPhone}" + "\n" + $"{StudentAddress}");
        }
    }
}
