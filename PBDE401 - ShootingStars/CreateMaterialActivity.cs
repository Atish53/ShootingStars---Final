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
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "CreateMaterialActivity")]
    public class CreateMaterialActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_upload); //activity admin layout
            // Create your application here

            //Add Materials Button
            Button uploadMaterials = FindViewById<Button>(Resource.Id.button_upload);

            uploadMaterials.Click += UploadMaterials_ClickAsync;
        }

        private async System.Threading.Tasks.Task UploadMaterials_ClickAsync(object sender, EventArgs e)
        {
            string db_name = "student_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);


            var customFileType =
                new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "com.adobe.pdf" } },
                    { DevicePlatform.Android, new[] { "application/pdf" } },
                    { DevicePlatform.UWP, new[] { ".pdf" } },
                    { DevicePlatform.Tizen, new[] { "*/*" } },
                    { DevicePlatform.macOS, new[] { "pdf" } },
                });            

            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                //FileTypes = FilePickerFileType.Images,
                FileTypes = customFileType,
                PickerTitle = "Pick an image"

            });

            SubjectMaterial upload = new SubjectMaterial() { itemName = pickResult.FileName, mediaType = pickResult.ContentType, };

            if (pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                
            }
        }
    }
}