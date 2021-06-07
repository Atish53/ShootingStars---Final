using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework
{
    class QuizBank
    {
        [Key]
        public int QuestionID { get; set; }

        public int QuizID { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
