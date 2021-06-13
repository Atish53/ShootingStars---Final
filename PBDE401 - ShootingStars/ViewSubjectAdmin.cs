using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntityFramework;
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "ViewSubjectActivity")]
    public class ViewSubjectAdmin : ListActivity
    {
        List<Subject> subjects;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            subjects = new List<Subject>();
            subjects = DatabaseHelper.ReadSubjects(db_path);

            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, subjects);
            this.ListAdapter = arrayAdapter;
        }
    }
}