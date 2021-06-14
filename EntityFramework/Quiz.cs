using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace EntityFramework
{
    public class Quiz
    {
        [PrimaryKey, AutoIncrement]
        public int QuizID { get; set; }

        public string QuizName { get; set; }

        [ForeignKey(typeof(Subject))]
        public int SubjectID { get; set; }

        public string Question1 { get; set; }

        public string Answer1 { get; set; }

        public string Question2 { get; set; }

        public string Answer2 { get; set; }

        public string Question3 { get; set; }

        public string Answer3 { get; set; }

        public string Question4 { get; set; }

        public string Answer4 { get; set; }

        public string Question5 { get; set; }

        public string Answer5 { get; set; }
    }
}
