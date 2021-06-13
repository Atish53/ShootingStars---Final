using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using EntityFramework;
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "CreateMaterialActivity")]
    public class CreateMaterialActivity : Activity
    {
        byte[] document;
        Spinner Spinner;
        List<Subject> Subjects;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_upload); //activity admin layout
            // Create your application here

            //Add Materials Button
            Button uploadMaterials = FindViewById<Button>(Resource.Id.button_upload);

            
            string db_name = "student_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            /*Spinner = (Spinner)FindViewById(Resource.Id.subject_dropdown);
            //Using DataBaseHelper to get a list of subjects via a method called GetStudents()
            Subjects = DatabaseHelper.ReadSubjects(db_path);

            ArrayAdapter dataAdapter = new ArrayAdapter(this,
                Android.Resource.Layout.SimpleSpinnerItem, Subjects);  //simple_spinner_item
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);//simple_spinner_dropdown_item

            Spinner.Adapter = dataAdapter;*/

            uploadMaterials.Click += UploadMaterials_Click;
        }

        private async void UploadMaterials_Click(object sender, EventArgs e)
        {
            string db_name = "student_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = Path.Combine(folderPath, db_name);

            var memoryStream = new MemoryStream();

            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Pdf,
                PickerTitle = "Pick a document"
            });

            if (pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                stream.CopyTo(memoryStream);
                document = memoryStream.ToArray();

                SubjectMaterial upload = new SubjectMaterial() { itemName = pickResult.FileName, mediaType = pickResult.ContentType, itemData = document, SubjectID = 1 };

                if (DatabaseHelper.Insert(ref upload, db_path)) //Pushes and checks if the document has been stored successfully.
                {
                    View view = (View)sender;
                    Toast.MakeText(Application.Context, pickResult.FileName + " has been uploaded successfully.", ToastLength.Long).Show();
                    stream.Close();
                    memoryStream.Close();
                }

                
            }
        }
    }
}