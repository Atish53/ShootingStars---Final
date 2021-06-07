using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework
{
    class Quiz
    {
        [Key]
        public int QuizID { get; set; }

        public string QuizName { get; set; }

        public int SubjectID { get; set; }

        public int Answer { get; set; }
    }
}
