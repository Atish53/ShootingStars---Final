using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "GetStudents", MainLauncher = true)]
    public class GetStudentsActivity : ListActivity
    {
        List<Student> students;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            students = new List<Student>();
            students = DatabaseHelper.Read(db_path);

            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, students);
            this.ListAdapter = arrayAdapter;
        }
    }
}