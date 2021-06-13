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
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText studentName, studentEmail, studentPassword, studentConfirmPassword, studentPhone, studentAddress;
        Button registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_register); //activity main layout
            // Create your application here

            studentName = FindViewById<EditText>(Resource.Id.register_name);
            studentEmail = FindViewById<EditText>(Resource.Id.register_email);
            studentPassword = FindViewById<EditText>(Resource.Id.register_password);
            studentPhone = FindViewById<EditText>(Resource.Id.register_cellphone);
            studentConfirmPassword = FindViewById<EditText>(Resource.Id.register_confirmpassword);
            studentAddress = FindViewById<EditText>(Resource.Id.register_address);

            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            registerButton.Click += registerButton_Click;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void registerButton_Click(object sender, EventArgs args)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            int count = 0;

            string sName, sEmail, sPass, sConfirmPass, sPhone, sAddress;

            sName = studentName.Text;
            sEmail = studentEmail.Text;
            sPass = studentPassword.Text;
            sConfirmPass = studentConfirmPassword.Text;
            sPhone = studentPhone.Text;
            sAddress = studentAddress.Text;

            bool isDigitPresent = sPhone.Any(c => char.IsDigit(c));

            //Validation using SnackBar to display error messages.
            if ((sAddress.Length == 0) || (sName.Length == 0)) //Maps API FOR ADDRESS
            {
                View view = (View)sender;
                Snackbar.Make(view, "Please fill in all the fields.", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                count++;
            }
            else if (sPass != sConfirmPass)
            {
                View view = (View)sender;
                Snackbar.Make(view, "Passwords do not match.", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                count++;
            }
            else if (sPass.Length < 8)
            {
                View view = (View)sender;
                Snackbar.Make(view, "Password needs to be at least 8 characters.", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                count++;
            }            
            else if ((isDigitPresent != true) && (sPhone.Length != 10))
            {
                View view = (View)sender;
                Snackbar.Make(view, "Phone number cannot contain letters.", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                count++;
            }
            else if (IsValidEmail(sEmail) != true) 
            {
                View view = (View)sender;
                Snackbar.Make(view, "Email address not valid.", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                count++;
            }
            if (count == 0)
            {
                Student newStudent = new Student() { StudentName = sName, StudentEmail = sEmail, StudentPassword = sPass, StudentAddress = sAddress, StudentPhone = sPhone };
                if (DatabaseHelper.Insert(ref newStudent, db_path)) //Pushes and checks if student data has been stored successfully.
                {
                    View view = (View)sender;
                    Snackbar.Make(view, "You have registered successfully.", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                    Preferences.Set("LoginState", "True");
                    Preferences.Set("LoginName", sName);
                    Preferences.Set("LoginEmail", sEmail);
                    Preferences.Set("LoginPhone", sPhone);
                    Preferences.Set("LoginAddress", sAddress);
                    Finish();
                }                    
                else
                {
                    View view = (View)sender;
                    Snackbar.Make(view, "Fatal error has occured.", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                }                   
            }                                 
        }
    }
}