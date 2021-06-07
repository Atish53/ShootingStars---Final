using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
