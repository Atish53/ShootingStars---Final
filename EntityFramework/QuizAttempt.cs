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

        public double Mark { get; set; }

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

        //Correct Answers

        public string CorrectAnswer1 { get; set; }
        public string CorrectAnswer2 { get; set; }
        public string CorrectAnswer3 { get; set; }
        public string CorrectAnswer4 { get; set; }
        public string CorrectAnswer5 { get; set; }

        //public double Duration { get; set; } If we have time left

        public override string ToString()
        {
            return string.Format("Date:" + " " + $"{DateAttempted}" + "\n" + "Quiz Attempt ID: " + $"{QuizAttemptID}" + "\n" + "Mark: " + $"{Mark}");
        }
    }
}
