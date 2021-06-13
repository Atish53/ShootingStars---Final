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
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity
    {
        Button Button1, Button2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GoogleMap_layout);

            // Create your application here

            Button1 = FindViewById<Button>(Resource.Id.btnLoc1);
            Button2 = FindViewById<Button>(Resource.Id.btnloc2);

            Button1.Click += Button1_Clicked;
            Button2.Click += Button2_Clicked;
        }

        private async void Button1_Clicked(object sender, EventArgs e)
        {
            var location = new Location(-25.741449, 28.189774);
            var options = new MapLaunchOptions { Name = "Resevoir Hills Library" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {

            }
        }
        private void Button2_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}