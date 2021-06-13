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
    [Activity(Label = "CreateSubjectActivity")]
    public class CreateSubjectActivity : Activity
    {
        Button createButton;
        EditText subjectGradeText, subjectNameText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_create_subject); //activity create subject layout
            // Create your application here
            createButton = FindViewById<Button>(Resource.Id.make_subject);
            createButton.Click += createQuery_Click;

            subjectGradeText = FindViewById<EditText>(Resource.Id.subject_grade);
            subjectNameText = FindViewById<EditText>(Resource.Id.subject_text);
        }

        private void createQuery_Click(object sender, EventArgs e)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            Subject subject = new Subject { SubjectName = subjectGradeText.Text, SubjectGrade = subjectNameText.Text};
            if (DatabaseHelper.Insert(ref subject, db_path)) //Pushes and checks if subject data has been stored successfully.
            {
                View view = (View)sender;
                Toast.MakeText(Application.Context, subjectNameText.Text + " has been created successfully.", ToastLength.Long).Show();
            }
            Finish();
        }
    }    
}