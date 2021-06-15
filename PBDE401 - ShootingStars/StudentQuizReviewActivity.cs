using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using EntityFramework;
using Java.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "StudentQuizReviewActivity")]
    public class StudentQuizReviewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_review); //activity admin layout
            // Create your application here

            //Add Materials Button
            Button generate_pdf = FindViewById<Button>(Resource.Id.generate_pdf);

            TextView q1 = FindViewById<TextView>(Resource.Id.q1_q);
            TextView q2 = FindViewById<TextView>(Resource.Id.q2_q);
            TextView q3 = FindViewById<TextView>(Resource.Id.q3_q);
            TextView q4 = FindViewById<TextView>(Resource.Id.q4_q);
            TextView q5 = FindViewById<TextView>(Resource.Id.q5_q);

            TextView a1 = FindViewById<TextView>(Resource.Id.a1_q);
            TextView a2 = FindViewById<TextView>(Resource.Id.a2_q);
            TextView a3 = FindViewById<TextView>(Resource.Id.a3_q);
            TextView a4 = FindViewById<TextView>(Resource.Id.a4_q);
            TextView a5 = FindViewById<TextView>(Resource.Id.a5_q);

            TextView a1c = FindViewById<TextView>(Resource.Id.a1c_q);
            TextView a2c = FindViewById<TextView>(Resource.Id.a2c_q);
            TextView a3c = FindViewById<TextView>(Resource.Id.a3c_q);
            TextView a4c = FindViewById<TextView>(Resource.Id.a4c_q);
            TextView a5c = FindViewById<TextView>(Resource.Id.a5c_q);

            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);

            QuizAttempt quiz = DatabaseHelper.ReadSingleQuizAttempt(db_path, 2);

            q1.Text = quiz.Question1;
            q2.Text = quiz.Question2;
            q3.Text = quiz.Question3;
            q4.Text = quiz.Question4;
            q5.Text = quiz.Question5;

            a1c.Text = quiz.CorrectAnswer1;
            a2c.Text = quiz.CorrectAnswer2;
            a3c.Text = quiz.CorrectAnswer3;
            a4c.Text = quiz.CorrectAnswer4;
            a5c.Text = quiz.CorrectAnswer5;

            a1.Text = quiz.Answer1;
            a2.Text = quiz.Answer2;
            a3.Text = quiz.Answer3;
            a4.Text = quiz.Answer4;
            a5.Text = quiz.Answer5;

            generate_pdf.Click += Generate_pdf_Click;
        }

        async void Generate_pdf_Click(object sender, EventArgs e)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for a page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));

            //Save the document to the stream
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //Close the document
            document.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            SaveAndroid androidSave = new SaveAndroid();
            //await androidSave.SaveAndView("Output.pdf", "application/pdf", stream, this);            
        }
    }

    class SaveAndroid
    {
        //Method to save document as a file in Android and view the saved document
        public async Task SaveAndView(string fileName, String contentType, MemoryStream stream, AppCompatActivity activity)
        {
            string root = null;
            //Get the root path in android device
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            //Create directory and file 
            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            //Remove if the file exists
            if (file.Exists()) file.Delete();

            //Write the stream into the file
            FileOutputStream outs = new FileOutputStream(file);
            outs.Write(stream.ToArray());

            outs.Flush();
            outs.Close();

            //Invoke the created file for viewing
            if (file.Exists())
            {
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.AddFlags(ActivityFlags.NewTask);
                intent.SetDataAndType(path, mimeType);
                activity.StartActivity(Intent.CreateChooser(intent, "Choose App"));
            }
        }
    }

}