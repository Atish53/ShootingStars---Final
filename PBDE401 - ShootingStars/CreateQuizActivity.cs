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
        Spinner subjects;
        EditText createQuizText, Q1, A1, Q2, A2, Q3, A3, Q4, A4, Q5, A5;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_create_quiz); //activity create quiz layout

            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);
            // Create your application here

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

            subjects = FindViewById<Spinner>(Resource.Id.spinner_quizsub);
            List<Subject> subjectList = DatabaseHelper.ReadSubjects(db_path);

            var adapter = new ArrayAdapter<Subject>(this, Android.Resource.Layout.SimpleSpinnerItem, subjectList);
            subjects.Adapter = adapter;

            subjects.ItemSelected += (sender, e) =>
            {                
                var s = sender as Spinner;
            };

            createButton = FindViewById<Button>(Resource.Id.make_quiz);
            createButton.Click += createQuiz_Click;    
        }

        private void createQuiz_Click(object sender, EventArgs e)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            //int SubjectIDs = DatabaseHelper.GetSubjectWithName(db_path, createQuizSubjectID.Text);

            Quiz newQuiz = new Quiz() { QuizName = createQuizText.Text, SubjectID = 1, Answer1 = A1.Text, Answer2 = A2.Text, Answer3 = A3.Text, Answer4 = A4.Text, Answer5 = A5.Text, Question1 = Q1.Text, Question2 = Q2.Text, Question3 = Q3.Text, Question4 = Q4.Text, Question5 = Q5.Text};
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