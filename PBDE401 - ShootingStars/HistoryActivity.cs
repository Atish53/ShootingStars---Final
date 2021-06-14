using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
    [Activity(Label = "HistoryActivity")]
    public class HistoryActivity : ListActivity
    {
        List<SubjectMaterial> subjectMaterials;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.History_layout);
            base.OnCreate(savedInstanceState);

            // Create your application here

            string db_name = "material_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            subjectMaterials = new List<SubjectMaterial>();
            subjectMaterials = DatabaseHelper.ReadMaterials(db_path);

            //ListEnglish.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, subjectMaterials);
            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, subjectMaterials);
            this.ListAdapter = arrayAdapter;
        }
    }
}