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
using System.IO;
using EntityFramework;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "StudentActivity")]
    public class StudentActivity : Activity
    {
        EditText NameEditText, EmailEditText, PasswordEditText, PhoneEditText, AddressEditText;
        Button Savebutton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Addstudent_layout);

            // Create your application here
            NameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
            EmailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            PasswordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            PhoneEditText = FindViewById<EditText>(Resource.Id.phoneEditText);
            AddressEditText = FindViewById<EditText>(Resource.Id.phoneEditText);
            Savebutton = FindViewById<Button>(Resource.Id.savebutton);

            Savebutton.Click += Savebutton_Click;
        }

        private void Savebutton_Click(object sender, EventArgs args)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            Student newStudent = new Student() { StudentName = NameEditText.Text , StudentEmail = EmailEditText.Text, StudentPassword = PasswordEditText.Text, StudentAddress = AddressEditText.Text};

            if (DatabaseHelper.Insert(ref newStudent, db_path))
                Console.WriteLine("SUCCESS");
            else
                Console.WriteLine("FAILURE");
        }
    }
}