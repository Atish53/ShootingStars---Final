using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EntityFramework;
using Java.IO;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "ViewAttemptActivity")]
    public class ViewAttemptActivity : Activity
    {
        List<QuizAttempt> quizAttempts;
        ListView customList;
        Button quizEnglish;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string[] perm = new string[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.WriteExternalStorage };
            RequestPermissions(perm, 325);

            SetContentView(Resource.Layout.activity_viewattempts);
            base.OnCreate(savedInstanceState);

            // Create your application here
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);

            quizAttempts = new List<QuizAttempt>();
            quizAttempts = DatabaseHelper.ReadQuizAttempts(db_path);

            customList = FindViewById<ListView>(Resource.Id.list_attempts);
            customList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, quizAttempts);

            customList.ItemClick += CustomList_ItemClick;
        }

        private void CustomList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string db_name = "students_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);
            QuizAttempt quizAttempt = DatabaseHelper.ReadSingleQuizAttempt(db_path, 1);

            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Email Report to your current email address");
            alert.SetMessage("Do you want to receive a copy of the report for this attempt via email?");
            alert.SetButton("Yes", (c, ev) =>
            {
                var loginEmail = Preferences.Get("LoginEmail", "None");

                //Create a new PDF document.
                PdfDocument doc = new PdfDocument();
                //Add a page.
                PdfPage page = doc.Pages.Add();
                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                //Add values to list
                List<object> data = new List<object>();
                Object row1 = new { Q = quizAttempt.Question1, A = quizAttempt.Answer1, CA = quizAttempt.CorrectAnswer1 };
                Object row2 = new { Q = quizAttempt.Question2, A = quizAttempt.Answer2, CA = quizAttempt.CorrectAnswer2 };
                Object row3 = new { Q = quizAttempt.Question3, A = quizAttempt.Answer3, CA = quizAttempt.CorrectAnswer3 };
                Object row4 = new { Q = quizAttempt.Question4, A = quizAttempt.Answer4, CA = quizAttempt.CorrectAnswer4 };
                Object row5 = new { Q = quizAttempt.Question5, A = quizAttempt.Answer5, CA = quizAttempt.CorrectAnswer5 };
                data.Add(row1);
                data.Add(row2);
                data.Add(row3);
                data.Add(row4);
                data.Add(row5);
                //Add list to IEnumerable
                IEnumerable<object> dataTable = data;
                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new PointF(10, 10));
                //Save the PDF document to stream.                
                MemoryStream outputStream = new MemoryStream();
                doc.Save(outputStream);
                outputStream.Position = 0;

                var invoicePdf = new System.Net.Mail.Attachment(outputStream, System.Net.Mime.MediaTypeNames.Application.Pdf);
                string docname = "Quiz.pdf";
                invoicePdf.ContentDisposition.FileName = docname;

                MailMessage mail = new MailMessage();
                string emailTo = loginEmail;
                MailAddress from = new MailAddress("21825470@dut4life.ac.za");
                mail.From = from;
                mail.Subject = "Your report for quiz attempt #" + quizAttempt.QuizAttemptID;
                mail.Body = "Dear " + loginEmail + ", find your progress in the attached PDF document.";
                mail.To.Add(emailTo);

                mail.Attachments.Add(invoicePdf);

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential("21825470@dut4life.ac.za", "Dut000605");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);
                //Clean-up.
                //Close the document.
                doc.Close(true);
                //Dispose of email.
                mail.Dispose();

            });
            alert.SetButton2("Cancel", (c, ev) => { });
            alert.Show();
        }
    }
}