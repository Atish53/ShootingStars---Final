﻿using System;
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
    [Activity(Label = "CreateQuizActivity")]
    public class CreateQuizActivity : Activity
    {
        Button createButton;
        EditText createQuizText, createQuizSubjectID;
        int StudentID;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_create_quiz); //activity create query layout

            // Create your application here

            createButton = FindViewById<Button>(Resource.Id.make_query);
            createButton.Click += createQuiz_Click;

            createQuizSubjectID = FindViewById<EditText>(Resource.Id.quiz_subject);
            createQuizText = FindViewById<EditText>(Resource.Id.quiz_name);
        }

        private void createQuiz_Click(object sender, EventArgs e)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            Quiz quiz = new Quiz();
            

            Query newQuiz = new Query() { StudentID = StudentID, Message = createQuizText.Text };
            if (DatabaseHelper.Insert(ref newQuiz, db_path)) //Pushes and checks if query data has been stored successfully.
            {
                View view = (View)sender;
                Snackbar.Make(view, "Your quiz has been  successfully created.", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            }
            Finish();
        }
    }
}