using Android.Provider;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFramework
{
    public class SubjectMaterial
    {
        //Blob or Normal DB
        [PrimaryKey, AutoIncrement]
        public int SubjectMaterialID { get; set; }

        [ForeignKey(typeof(Subject))]
        public int SubjectID { get; set; }

        public string itemName { get; set; }

        //Actual Content
        public byte[] itemData { get; set; }

        public string mediaType { get; set; }
    }
}
