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
    [Activity(Label = "ResponseActivity")]
    public class ResponseActivity : Activity
    {
        int ids;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var id = Intent.Extras.GetInt("selectedItemId");
            ids = id;
            SetContentView(Resource.Layout.activity_response);
            // Create your application here

            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);

            TextView adminQuery = FindViewById<TextView>(Resource.Id.admin_query);
            TextView adminId = FindViewById<TextView>(Resource.Id.admin_queryId);
            TextView adminName = FindViewById<TextView>(Resource.Id.admin_queryname);

            EditText response = FindViewById<EditText>(Resource.Id.admin_response);

            CheckBox checkBox = FindViewById<CheckBox>(Resource.Id.completestatus);

            Button submit = FindViewById<Button>(Resource.Id.update_response);

            Query query = DatabaseHelper.ReadSingleQuery(db_path, id);

            adminQuery.Text = query.Message;
            adminId.Text = query.QueryID.ToString();
            adminName.Text = query.StudentID.ToString();

            submit.Click += Submit_Click;                         
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);

            TextView adminQuery = FindViewById<TextView>(Resource.Id.admin_query);
            TextView adminId = FindViewById<TextView>(Resource.Id.admin_queryId);
            TextView adminName = FindViewById<TextView>(Resource.Id.admin_queryname);

            EditText response = FindViewById<EditText>(Resource.Id.admin_response);

            CheckBox checkBox = FindViewById<CheckBox>(Resource.Id.completestatus);

            Button submit = FindViewById<Button>(Resource.Id.update_response);

            Query query = DatabaseHelper.ReadSingleQuery(db_path, ids);

            adminQuery.Text = query.Message;
            adminId.Text = query.QueryID.ToString();
            adminName.Text = query.StudentID.ToString();

            DatabaseHelper.UpdateQuery(db_path, ids, response.Text, checkBox.Checked);

        }
    }
}