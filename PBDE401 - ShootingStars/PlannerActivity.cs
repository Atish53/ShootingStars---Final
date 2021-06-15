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
using EntityFramework;

namespace PBDE401___ShootingStars
{
    [Activity(Label = "PlannerActivity")]
    public class PlannerActivity : Activity
    {
        private ListView _todoListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_planner);
            //_todoListView = FindViewById<ListView>(Resource.Id.planner_list);
        }

        protected override async void OnResume()
        {
            base.OnResume();

           // var todoList = await PlannerRepository.GetList();
           // var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, todoList.Select(t => t.Title).ToArray());
           // _todoListView.Adapter = adapter;
        }
    }
}