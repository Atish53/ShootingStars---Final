using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "SubjectsActivity")]
    public class SubjectsActivity : Activity
    {
        ImageButton English, History;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Subjects_layout);

            // Create your application here

            English = FindViewById<ImageButton>(Resource.Id.btnenglish);
            History = FindViewById<ImageButton>(Resource.Id.btnhistory);
            //Maths = FindViewById<ImageButton>(Resource.Id.btnmaths);
            //Biology = FindViewById<ImageButton>(Resource.Id.btnbiology);

            English.Click += English_Click;
            History.Click += History_Click;
            //Maths += Maths_Click;
            //Biology += Biology_Click;
        }

        private void History_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(HistoryActivity));
            StartActivity(intent);
        }

        private void English_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(EnglishActivity));
            StartActivity(intent);
        }

    }
}