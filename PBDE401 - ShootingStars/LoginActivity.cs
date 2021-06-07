using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntityFramework;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login); //activity main layout

            // Create your application here

            /* Button button = (Button)FindViewById(Resource.Id.login_button);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            TextView textView = FindViewById(Resource.Id.testView);

            var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var fileName = "Context.db";
            var dbFullPath = Path.Combine(dbFolder, fileName);
            try
            {
                using (var db = new Context(dbFullPath))
                {
                    await db.Database.MigrateAsync(); //We need to ensure the latest Migration was added. This is different than EnsureDatabaseCreated.

                    Student testStudent = new Student() { StudentID = 1, StudentName = "Gary", StudentAddress = "Test123", StudentEmail = "Test@123.net", StudentPassword = "Test123", StudentPhone = "0123456789" };
                    Student testStudent2 = new Student() { StudentID = 2, StudentName = "SpongeBob", StudentAddress = "Test234", StudentEmail = "Test@234.net", StudentPassword = "Test123", StudentPhone = "0123456789" };
                    Student testStudent3 = new Student() { StudentID = 3, StudentName = "Patrick", StudentAddress = "Test567", StudentEmail = "Test@567.net", StudentPassword = "Test123", StudentPhone = "0123456789" };

                    List listStudents = new List() { testStudent, testStudent2, testStudent3 };

                    if (await db.Students.CountAsync() < 3)
                    {
                        await db.Students.AddRangeAsync(listStudents);
                        await db.SaveChangesAsync();
                    }

                    var catsInTheBag = await db.Students.ToListAsync();

                    foreach (var student in listStudents)
                    {
                        textView.Text += "Success";
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}*/
        }
    }
}