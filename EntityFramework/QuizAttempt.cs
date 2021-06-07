using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework
{
    class QuizAttempt
    {
        public int StudentID { get; set; }
        public int QuizID { get; set; }
        public DateTime DateAttempted { get; set; }
        public int Mark { get; set; }
        public double Duration { get; set; }
    }
}
