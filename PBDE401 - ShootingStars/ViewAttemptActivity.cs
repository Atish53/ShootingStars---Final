using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntityFramework;
using Java.IO;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "ViewAttemptActivity")]
    public class ViewAttemptActivity : Activity
    {
        List<QuizAttempt> quizAttempts;
        ListView customList;
        Button quizEnglish;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string[] perm = new string[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.WriteExternalStorage };
            RequestPermissions(perm, 325);

            SetContentView(Resource.Layout.activity_viewattempts);
            base.OnCreate(savedInstanceState);

            // Create your application here
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);

            quizAttempts = new List<QuizAttempt>();
            quizAttempts = DatabaseHelper.ReadQuizAttempts(db_path);

            customList = FindViewById<ListView>(Resource.Id.list_attempts);
            customList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, quizAttempts);

            customList.ItemClick += CustomList_ItemClick;

        }

        private void CustomList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}