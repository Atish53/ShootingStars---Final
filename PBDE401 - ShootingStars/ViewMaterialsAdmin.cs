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

namespace PBDE401___ShootingStars
{
    [Activity(Label = "ViewMaterialsAdmin")]
    public class ViewMaterialsAdmin : ListActivity
    {
        List<SubjectMaterial> subjectMaterials;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            string db_name = "material_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            subjectMaterials = new List<SubjectMaterial>();
            subjectMaterials = DatabaseHelper.ReadMaterials(db_path);

            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, subjectMaterials);
            this.ListAdapter = arrayAdapter;
        }
    }
}