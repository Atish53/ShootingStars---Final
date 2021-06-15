using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using EntityFramework;
using Java.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "EnglishActivity")]
    public class EnglishActivity : Activity
    { 
        List<SubjectMaterial> subjectMaterials;
        ListView customList;
        Button quizEnglish;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string[] perm = new string[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.WriteExternalStorage };
            RequestPermissions(perm, 325);

            SetContentView(Resource.Layout.English_layout);
            base.OnCreate(savedInstanceState);

            // Create your application here
            string db_name = "material_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);

            quizEnglish = FindViewById<Button>(Resource.Id.quiz_english);
            quizEnglish.Click += QuizEnglish_Click;

            subjectMaterials = new List<SubjectMaterial>();
            subjectMaterials = DatabaseHelper.ReadMaterials(db_path);

            customList = FindViewById<ListView>(Resource.Id.customlist);
            customList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, subjectMaterials);

            customList.ItemClick += CustomList_ItemClick;

        }

        private void QuizEnglish_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AttemptQuizActivity));
            StartActivity(intent);
        }

        private async void CustomList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Download File");
            alert.SetMessage("Are you sure you want to download this file?");
            alert.SetButton("Yes", async (c, ev) =>
            {
                string db_name = "material_db.sqlite";
                string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string db_path = System.IO.Path.Combine(folderPath, db_name);

                SubjectMaterial subjectMaterial = DatabaseHelper.ReadSingleMaterials(db_path, 1);
                byte[] byteArray = subjectMaterial.itemData;

                //Add confirmation to download + Snackbar notification
                var filename = System.IO.Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).ToString(), "ShootingStars");
                Directory.CreateDirectory(filename);
                filename = System.IO.Path.Combine(filename, subjectMaterial.itemName);
                using (var fileOutputStream = new FileOutputStream(filename))
                {
                    await fileOutputStream.WriteAsync(byteArray);
                    View view = (View)sender;
                    Snackbar.Make(view, "Successfully downloaded " + subjectMaterial.itemName + "!", Snackbar.LengthLong)
                        .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
                }
                
            });
            alert.SetButton2("No", (c, ev) => { });
            alert.Show();
        }

        
    }
}
