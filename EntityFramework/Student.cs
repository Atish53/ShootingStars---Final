using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public string StudentEmail { get; set; }

        public string StudentPassword { get; set; }

        public string StudentPhone { get; set; }

        public string StudentAddress { get; set; }

    }
}
