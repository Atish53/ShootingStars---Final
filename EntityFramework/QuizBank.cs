using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace EntityFramework
{
    public class QuizBank
    {
        [PrimaryKey, AutoIncrement]
        public int QuestionID { get; set; }

        [ForeignKey(typeof(Quiz))]
        public int QuizID { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
