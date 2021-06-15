using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public string SubjectGrade { get; set; }

        [ForeignKey(typeof(SubjectMaterial))]
        public int SubjectMaterialID{ get; set; }

        public override string ToString()
        {
            return string.Format("Subject ID:"+ " " + $"{SubjectID}" + "\n" + "Subject Grade:"+ " " +$"{SubjectName}" + "\n" + "Subject Grade:"+ " " + $"{SubjectGrade}");
        }

        public string getName()
        {
            return SubjectName;
        }

    }
}
