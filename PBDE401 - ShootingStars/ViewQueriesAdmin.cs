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
    [Activity(Label = "ViewQueriesAdmin")]
    public class ViewQueriesAdmin : Activity
    {        
        List<Query> queries;
        ListView customList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_query_admin);
            base.OnCreate(savedInstanceState);

            // Create your application here

            string db_name = "material_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);

            queries = new List<Query>();
            queries = DatabaseHelper.ReadQueriesAdmin(db_path);

            customList = FindViewById<ListView>(Resource.Id.list_qadmin);
            customList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, queries);

            customList.ItemClick += CustomList_ItemClick;

        }

        private void CustomList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string db_name = "material_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string db_path = System.IO.Path.Combine(folderPath, db_name);

        }


    }
}