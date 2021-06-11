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

namespace PBDE401___ShootingStars
{
    [Activity(Label = "ManageMaterialsActivity")]
    public class ManageMaterialsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_manage_materials); //activity admin layout
            // Create your application here

            //Add Materials Button
            Button addMaterials = FindViewById<Button>(Resource.Id.add_materialslink);

            addMaterials.Click += (sender, e) =>
            {
                Intent addMaterialsIntent = new Intent(this, typeof(CreateMaterialActivity));
                StartActivity(addMaterialsIntent);
            };

            //View Current Materials Button
            Button viewMaterials = FindViewById<Button>(Resource.Id.view_materialslink);

            viewMaterials.Click += (sender, e) =>
            {
                Intent viewMaterialsIntent = new Intent(this, typeof(ViewMaterialsAdmin));
                StartActivity(viewMaterialsIntent);
            };

            
        }
    }
}