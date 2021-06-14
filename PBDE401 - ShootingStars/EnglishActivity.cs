using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using EntityFramework;
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

            subjectMaterials = new List<SubjectMaterial>();
            subjectMaterials = DatabaseHelper.ReadMaterials(db_path);

            customList = FindViewById<ListView>(Resource.Id.customlist);
            customList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, subjectMaterials);

            customList.ItemClick += CustomList_ItemClick;

        }

        private void CustomList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string db_name = "material_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);            
            
            SubjectMaterial subjectMaterial = DatabaseHelper.ReadSingleMaterials(db_path, "1");
            byte[] byteArray = subjectMaterial.itemData;
  
            string DownloadsPath = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
            string filePath = System.IO.Path.Combine(DownloadsPath, subjectMaterial.itemName);
            File.WriteAllBytes(filePath, byteArray);

        }

        
    }
}
