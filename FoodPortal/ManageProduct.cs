using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodPortal
{
    [Activity(Label = "ManageProduct")]
    public class ManageProduct : Activity
    {
        ListView lst;
        Android.Widget.Button btnBck, btnDel;
        int idx = -1;
        ArrayAdapter usr;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ManageProduct);
            // Create your application here
            SQLClass.Instnce.createTble();


            lst = FindViewById<ListView>(Resource.Id.lstUser);

            List<String> dt = SQLClass.Instnce.getList().Select(c => c.Product + " - " + c.Price).ToList();

            usr = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, dt);

            lst.Adapter = usr;
            lst.ItemClick += listClick;
            // Create your application here


            btnBck = FindViewById<Button>(Resource.Id.btnBck);
            btnBck.Click += new EventHandler(BtnBck_Clicked);

            btnDel = FindViewById<Button>(Resource.Id.btnDel);
            btnDel.Click += new EventHandler(BtnDelete_Clicked);




        }

        private void listClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int ps = e.Position;
            idx = ps;

        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var dt = SQLClass.Instnce.getList();
            ProductItems register = dt[idx];

            int y = SQLClass.Instnce.del(register);
            if (y == 1)
            {
                Toast.MakeText(Application.Context, "Product Removed ", ToastLength.Short).Show();
            }

            List<String> dt1 = SQLClass.Instnce.getList().Select(c => c.Product + " - " + c.Price).ToList();

            usr = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, dt1);

            lst.Adapter = usr;

        }

        private void BtnBck_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AdminZone));
            StartActivity(intent);
        }
    }
}