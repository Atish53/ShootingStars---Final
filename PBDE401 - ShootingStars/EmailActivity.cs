using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "EmailActivity")]
    public class EmailActivity : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState); // add this line to your code, it may also be called: bundle

            SetContentView(Resource.Layout.EmailLayout);
            // Create your application here

            var edtAddress = FindViewById<EditText>(Resource.Id.edtAddress);
            var edtSubject = FindViewById<EditText>(Resource.Id.edtSubject);
            var edtMessage = FindViewById<EditText>(Resource.Id.edtMessage);
            var btnSend = FindViewById<Button>(Resource.Id.sendemailbutton);

            btnSend.Click += (s, e) =>
            {
                Intent email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, new string[] { edtSubject.Text.ToString() });
                email.PutExtra(Intent.ExtraSubject, edtSubject.Text.ToString());
                email.PutExtra(Intent.ExtraText, edtMessage.Text.ToString());
                email.SetType("message/rfc822");
                StartActivity(Intent.CreateChooser(email, "Send Email Via"));
            };



        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

  
        

    }
}