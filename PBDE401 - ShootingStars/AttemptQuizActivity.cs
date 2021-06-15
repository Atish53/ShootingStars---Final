using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntityFramework;
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "AttemptQuizActivity")]
    public class AttemptQuizActivity : Activity
    {
        double mark;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_attempt_quiz); //activity admin layout
            // Create your application here

            //Add Materials Button
            Button submit = FindViewById<Button>(Resource.Id.quiz_submit);

            TextView q1 = FindViewById<TextView>(Resource.Id.quiz_q1);
            TextView q2 = FindViewById<TextView>(Resource.Id.quiz_q2);
            TextView q3 = FindViewById<TextView>(Resource.Id.quiz_q3);
            TextView q4 = FindViewById<TextView>(Resource.Id.quiz_q4);
            TextView q5 = FindViewById<TextView>(Resource.Id.quiz_q5);

            EditText a1 = FindViewById<EditText>(Resource.Id.quiz_a1);
            EditText a2 = FindViewById<EditText>(Resource.Id.quiz_a2);
            EditText a3 = FindViewById<EditText>(Resource.Id.quiz_a3);
            EditText a4 = FindViewById<EditText>(Resource.Id.quiz_a4);
            EditText a5 = FindViewById<EditText>(Resource.Id.quiz_a5);

            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            Quiz quiz = DatabaseHelper.ReadSingleQuiz(db_path, 1);

            q1.Text = quiz.Question1;
            q2.Text = quiz.Question2;
            q3.Text = quiz.Question3;
            q4.Text = quiz.Question4;
            q5.Text = quiz.Question5;
           
            submit.Click += Submit_Click;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Finish Attempt");
            alert.SetMessage("Are you sure you are done?");            
            alert.SetButton("Yes", (c, ev) =>
            {
                //On Yes Click 
                string db_name = "students_db.sqlite";
                string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string db_path = Path.Combine(folderPath, db_name);

                var loginEmail = Preferences.Get("LoginEmail", "None");
                Student currentStudent = DatabaseHelper.ReadSingle(db_path, loginEmail);
                int StudentIDs = currentStudent.StudentID;

                TextView q1 = FindViewById<TextView>(Resource.Id.quiz_q1);
                TextView q2 = FindViewById<TextView>(Resource.Id.quiz_q2);
                TextView q3 = FindViewById<TextView>(Resource.Id.quiz_q3);
                TextView q4 = FindViewById<TextView>(Resource.Id.quiz_q4);
                TextView q5 = FindViewById<TextView>(Resource.Id.quiz_q5);

                EditText a1 = FindViewById<EditText>(Resource.Id.quiz_a1);
                EditText a2 = FindViewById<EditText>(Resource.Id.quiz_a2);
                EditText a3 = FindViewById<EditText>(Resource.Id.quiz_a3);
                EditText a4 = FindViewById<EditText>(Resource.Id.quiz_a4);
                EditText a5 = FindViewById<EditText>(Resource.Id.quiz_a5);

                Quiz quiz = DatabaseHelper.ReadSingleQuiz(db_path, 1);

                int count = 0;
                if (a1.Text == quiz.Answer1)
                {
                    count++;
                }
                if (a2.Text == quiz.Answer2)
                {
                    count++;
                }
                if (a3.Text == quiz.Answer3)
                {
                    count++;
                }
                if (a4.Text == quiz.Answer4)
                {
                    count++;
                }
                if (a5.Text == quiz.Answer5)
                {
                    count++;
                }
                mark = (count / 5.00) * 100;

                QuizAttempt quizAttempt = new QuizAttempt() { StudentID = StudentIDs, QuizID = 3, Mark = mark, Answer1 = a1.Text, Answer2 = a2.Text, Answer3 = a3.Text, Answer4 = a4.Text, Answer5 = a5.Text, DateAttempted = DateTime.Now.Date, CorrectAnswer1 = quiz.Answer1, CorrectAnswer2 = quiz.Answer2, CorrectAnswer3 = quiz.Answer3, CorrectAnswer4 = quiz.Answer4, CorrectAnswer5 = quiz.Answer5, Question1 = quiz.Question1, Question2 = quiz.Question2, Question3 = quiz.Question3, Question4 = quiz.Question4, Question5 = quiz.Question5 };
                if (DatabaseHelper.Insert(ref quizAttempt, db_path)) //Pushes and checks if quiz attempt data has been stored successfully.
                {
                    View view = (View)sender;
                    Toast.MakeText(Application.Context, "You've scored " + count + " out of 5!", ToastLength.Long).Show();
                }
                Finish();
            });
            alert.SetButton2("No", (c, ev) => { });
            alert.Show();
        }
       

        }
    }
