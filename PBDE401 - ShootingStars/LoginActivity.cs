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
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        EditText studentEmail, studentPassword;
        Button registerButtonLogin, loginButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login); //activity main layout

            registerButtonLogin = FindViewById<Button>(Resource.Id.registerButtonLogin);
            // Create your application here

            registerButtonLogin.Click += (sender, e) => {
               // Perform action on click
               Intent StudentRegisterIntent = new Intent(this, typeof(RegisterActivity));
               StartActivity(StudentRegisterIntent);
            };

            studentEmail = FindViewById<EditText>(Resource.Id.login_studentEmail);
            studentPassword = FindViewById<EditText>(Resource.Id.login_studentPassword);

            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);            

            loginButton = FindViewById<Button>(Resource.Id.login_button);            

            loginButton.Click += (sender, e) => {
                // Validate Student Credentials
                if (DatabaseHelper.CheckLogin(db_path, studentEmail.Text, studentPassword.Text) == "Success")
                {
                    Student student = DatabaseHelper.ReadSingle(db_path, studentEmail.Text);
                    Preferences.Set("LoginState", "True");
                    Preferences.Set("LoginName", student.StudentName);
                    Preferences.Set("LoginEmail", student.StudentEmail);
                    Preferences.Set("LoginPhone", student.StudentPhone);
                    Preferences.Set("LoginAddress", student.StudentAddress);

                    View view = (View)sender;

                    Toast.MakeText(Application.Context, "Welcome, " + student.StudentName + ". You've logged in successfully.", ToastLength.Long).Show();

                    Intent StudentLoginIntent = new Intent(this, typeof(MainActivity));
                    StartActivity(StudentLoginIntent);
                    Finish();
                }
                else if (DatabaseHelper.CheckLogin(db_path, studentEmail.Text, studentPassword.Text) == "Invalid")
                {
                    View view = (View)sender;
                    Snackbar.Make(view, "Invalid Password.", Snackbar.LengthLong)
                        .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();

                }
                else if (DatabaseHelper.CheckLogin(db_path, studentEmail.Text, studentPassword.Text) == "NotFound")
                {
                    View view = (View)sender;
                    Snackbar.Make(view, "Student Not Found.", Snackbar.LengthLong)
                        .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                }
            };
        }
    }
}