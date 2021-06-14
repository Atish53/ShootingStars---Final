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

        public int SubjectID { get; set; }

        public int Answer { get; set; }
    }
}
