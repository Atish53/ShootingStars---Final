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
    [Activity(Label = "CreateQuizActivity")]
    public class CreateQuizActivity : Activity
    {
        Button createButton;
        EditText createQuizText, createQuizSubjectID, Q1, A1, Q2, A2, Q3, A3, Q4, A4, Q5, A5;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_create_quiz); //activity create query layout

            // Create your application here
            createQuizSubjectID = FindViewById<EditText>(Resource.Id.quiz_subject); //Textbox for subject
            createQuizText = FindViewById<EditText>(Resource.Id.quiz_name);
            Q1 = FindViewById<EditText>(Resource.Id.question1);
            A1 = FindViewById<EditText>(Resource.Id.answer1);
            Q2 = FindViewById<EditText>(Resource.Id.question2);
            A2 = FindViewById<EditText>(Resource.Id.answer2);
            Q3 = FindViewById<EditText>(Resource.Id.question3);
            A3 = FindViewById<EditText>(Resource.Id.answer3);
            Q4 = FindViewById<EditText>(Resource.Id.question4);
            A4 = FindViewById<EditText>(Resource.Id.answer4);
            Q5 = FindViewById<EditText>(Resource.Id.question5);
            A5 = FindViewById<EditText>(Resource.Id.answer5);

            createButton = FindViewById<Button>(Resource.Id.make_quiz);

            createButton.Click += createQuiz_Click;

    
        }

        private void createQuiz_Click(object sender, EventArgs e)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            Quiz quiz = new Quiz();
            

            Quiz newQuiz = new Quiz() { QuizName = createQuizText.Text, SubjectID = int.Parse(createQuizSubjectID.Text)};
            if (DatabaseHelper.Insert(ref newQuiz, db_path)) //Pushes and checks if quiz data has been stored successfully.
            {
                View view = (View)sender;
                Snackbar.Make(view, "Your quiz has been  successfully created.", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            }
            Finish();
        }
    }
}