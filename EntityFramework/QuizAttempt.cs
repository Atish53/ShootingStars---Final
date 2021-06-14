using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework
{
    public class QuizAttempt
    {
        [PrimaryKey, AutoIncrement]
        public int QuizAttemptID { get; set; }

        [ForeignKey(typeof(Student))]
        public int StudentID { get; set; }

        [ForeignKey(typeof(Quiz))]
        public int QuizID { get; set; }

        public DateTime DateAttempted { get; set; }

        public int Mark { get; set; }

        //public double Duration { get; set; } If we have time left
    }
}
