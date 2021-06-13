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
    [Activity(Label = "ManageSubjectsActivity")]
    public class ManageSubjectsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_manage_subjects); //activity admin layout
            // Create your application here

            //Add Subjects Button
            Button addSubjects = FindViewById<Button>(Resource.Id.add_subjectslink);

            addSubjects.Click += (sender, e) =>
            {
                Intent addSubjectIntent = new Intent(this, typeof(CreateSubjectActivity));
                StartActivity(addSubjectIntent);
            };

            //View Current Subjects Button
            Button viewSubjects = FindViewById<Button>(Resource.Id.view_subjectslink);
            viewSubjects.Click += (sender, e) =>
            {
                Intent viewSubjectIntent = new Intent(this, typeof(ViewSubjectAdmin));
                StartActivity(viewSubjectIntent);
            };
        }
    }
}