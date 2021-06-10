using System;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "ShootingStars", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main); //activity main layout
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);

            var loginState = Preferences.Get("LoginState", "False");
            var loginName = Preferences.Get("LoginName", "None");
            var loginEmail = Preferences.Get("LoginEmail", "None");

            TextView logged_Name = FindViewById<TextView>(Resource.Id.logged_name);
            logged_Name.Text = loginName.ToString();

            TextView logged_Email = FindViewById<TextView>(Resource.Id.logged_email);
            logged_Email.Text = loginEmail.ToString();
            
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        

        //ChatBot
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            var loginState = Preferences.Get("LoginState", "False");      
            int id = item.ItemId;
            
            if (loginState == "False")
            {
                if (id == Resource.Id.nav_grades)
                {
                    // Handle the grades action
                }
                else if (id == Resource.Id.nav_subjects)
                {
                    Intent StudentIntent = new Intent(this, typeof(StudentActivity));
                    StartActivity(StudentIntent);
                }
                else if (id == Resource.Id.nav_planner)
                {
                    Intent GetStudentIntent = new Intent(this, typeof(GetStudentsActivity));
                    StartActivity(GetStudentIntent);
                }
                else if (id == Resource.Id.nav_feedback)
                {

                }
                else if (id == Resource.Id.nav_additionalresources)
                {

                }
                else if (id == Resource.Id.nav_question)
                {
                    Intent queryIntent = new Intent(this, typeof(QueryActivity));
                    StartActivity(queryIntent);
                }
                else if (id == Resource.Id.nav_login)
                {
                    Intent loginIntent = new Intent(this, typeof(LoginActivity));
                    StartActivity(loginIntent);
                }
            }
            else if (loginState == "True")
            {
                if (id == Resource.Id.nav_grades)
                {
                    // Handle the grades action
                }
                else if (id == Resource.Id.nav_subjects)
                {
                    Intent StudentIntent = new Intent(this, typeof(StudentActivity));
                    StartActivity(StudentIntent);
                }
                else if (id == Resource.Id.nav_planner)
                {
                    Intent GetStudentIntent = new Intent(this, typeof(GetStudentsActivity));
                    StartActivity(GetStudentIntent);
                }
                else if (id == Resource.Id.nav_feedback)
                {

                }
                else if (id == Resource.Id.nav_additionalresources)
                {

                }
                else if (id == Resource.Id.nav_question)
                {
                    Intent queryIntent = new Intent(this, typeof(QueryActivity));
                    StartActivity(queryIntent);
                }
                else if (id == Resource.Id.nav_login)
                {
                    Intent loginIntent = new Intent(this, typeof(LoginActivity));
                    StartActivity(loginIntent);
                }

            }
            

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

//Maps
//Progress
//ChatBot
