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
        Button Button1, Button2, Button3, Button4, Button5;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GoogleMap_layout);

            // Create your application here

            Button1 = FindViewById<Button>(Resource.Id.btnLoc1);
            Button2 = FindViewById<Button>(Resource.Id.btnloc2);
            Button3 = FindViewById<Button>(Resource.Id.btnloc3);
            Button4 = FindViewById<Button>(Resource.Id.btnloc4);
            Button5 = FindViewById<Button>(Resource.Id.btnloc5);

            Button1.Click += Button1_Clicked;
            Button2.Click += Button2_Clicked;
            Button3.Click += Button3_Clicked;
            Button4.Click += Button4_Clicked;
            Button5.Click += Button5_Clicked;
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
        private async void Button2_Clicked(object sender, EventArgs e)
        {
            var location = new Location(-29.785736, 31.03898);
            var options = new MapLaunchOptions { Name = "DURBAN NORTH MUNICIPAL LIBRARY" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {

            }
        }
        private async void Button3_Clicked(object sender, EventArgs e)
        {
            var location = new Location(-29.7802639, 30.9565085);
            var options = new MapLaunchOptions { Name = "New West Library" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {

            }
        }

        private async void Button4_Clicked(object sender, EventArgs e)
        {
            var location = new Location(-29.669934, 31.115962);
            var options = new MapLaunchOptions { Name = "Umdloti Library" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {

            }
        }
        private async void Button5_Clicked(object sender, EventArgs e)
        {
            var location = new Location(-29.8535507, 31.0052107);
            var options = new MapLaunchOptions { Name = "Durban University of Technology Library" };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {

            }
        }

    }
}