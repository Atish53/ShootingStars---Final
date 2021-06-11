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
    [Activity(Label = "CreateMaterialActivity")]
    public class CreateMaterialActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_create_materials); //activity admin layout
            // Create your application here

            //Add Materials Button
            Button uploadMaterials = FindViewById<Button>(Resource.Id.create_query);

            uploadMaterials.Click += (sender, e) =>
            {
                Intent addMaterialsIntent = new Intent(this, typeof(CreateMaterialActivity));
                StartActivity(addMaterialsIntent);
            };
        }
    }
}