using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.RecyclerView.Extensions;
using Android.Views;
using Android.Widget;
using EntityFramework;
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "QueryActivity")]
    public class QueryActivity : Activity
    {
        Button queryCreateButton, queryView;
        ListView mainList;
        List<Query> Queries;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var loginEmail = Preferences.Get("LoginEmail", "None");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_query); //activity main layout

            // Create your application here
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            queryCreateButton = FindViewById<Button>(Resource.Id.create_query);

            queryCreateButton.Click += (sender, e) =>
            {
                Intent createQueryIntent = new Intent(this, typeof(CreateQueryActivity));
                StartActivity(createQueryIntent);
            };

            queryView = FindViewById<Button>(Resource.Id.view_query);

            queryView.Click += (sender, e) =>
            {
                Intent viewQueryIntent = new Intent(this, typeof(ActiveQueriesActivity));
                StartActivity(viewQueryIntent);
            };





        }
    }
}