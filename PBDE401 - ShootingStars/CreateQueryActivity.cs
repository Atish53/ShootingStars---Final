using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using EntityFramework;
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "CreateQueryActivity")]
    public class CreateQueryActivity : Activity
    {
        Button createButton;
        EditText createQueryText;
        int StudentID;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_create_query); //activity create query layout

            // Create your application here

            createButton = FindViewById<Button>(Resource.Id.make_query);
            createButton.Click += createQuery_Click;

            createQueryText = FindViewById<EditText>(Resource.Id.query_text);
        }

        private void createQuery_Click(object sender, EventArgs e)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            var loginEmail = Preferences.Get("LoginEmail", "None");
            Student currentStudent = DatabaseHelper.ReadSingle(db_path, loginEmail);
            StudentID = currentStudent.StudentID;

            Query newQuery = new Query() { StudentID = StudentID, Message = createQueryText.Text };
            if (DatabaseHelper.Insert(ref newQuery, db_path)) //Pushes and checks if query data has been stored successfully.
            {
                View view = (View)sender;
                Toast.MakeText(Application.Context, "Your query has been created successfully.", ToastLength.Long).Show();
            }
            Finish();
        }
    }
}