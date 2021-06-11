using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework
{
    class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public int SubjectGrade { get; set; }
        
        public virtual List<SubjectMaterial> Materials { get; set; }



    }
}
