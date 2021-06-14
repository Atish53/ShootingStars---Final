using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "AdminActivity")]
    public class AdminActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_admin); //activity admin layout
            // Create your application here

            //Admin Materials Button
            Button adminMaterials = FindViewById<Button>(Resource.Id.manage_materials);

            adminMaterials.Click += (sender, e) =>
            {
                Intent manageMaterials = new Intent(this, typeof(ManageMaterialsActivity));
                StartActivity(manageMaterials);
            };

            //Admin Queries
            Button adminQueries = FindViewById<Button>(Resource.Id.manage_queries);

            adminQueries.Click += (sender, e) =>
            {
                Intent manageQueries = new Intent(this, typeof(ViewQueriesAdmin));
                StartActivity(manageQueries);
            };

            //Admin Quiz
            Button adminQuiz = FindViewById<Button>(Resource.Id.manage_quiz);

            adminQuiz.Click += (sender, e) =>
            {
                Intent manageQuiz = new Intent(this, typeof(ManageQuizActivity));
                StartActivity(manageQuiz);
            };

            //Admin Subject
            Button subjectQuiz = FindViewById<Button>(Resource.Id.manage_subject);

            subjectQuiz.Click += (sender, e) =>
            {
                Intent manageSubject = new Intent(this, typeof(ManageSubjectsActivity));
                StartActivity(manageSubject);
            };



        }
    }
}