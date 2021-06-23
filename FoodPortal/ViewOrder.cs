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
    [Activity(Label = "ViewOrder")]
    public class ViewOrder : Activity
    {
        ListView lst;
        Android.Widget.Button btnBck, btnDel;
        int idx = -1;
        ArrayAdapter usr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderList);
            SQLClass.Instnce.createOrderTble();


            lst = FindViewById<ListView>(Resource.Id.lstOrder);

            List<String> dt = SQLClass.Instnce.getOrderList().Select(c => c.Name+"-"+c.Product + " - " + c.Price).ToList();

            usr = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, dt);

            lst.Adapter = usr;
            lst.ItemClick += listClick;
            // Create your application here


            btnBck = FindViewById<Button>(Resource.Id.btnBck);
            btnBck.Click += new EventHandler(BtnBck_Clicked);

            btnDel = FindViewById<Button>(Resource.Id.btnOrderDel);
            btnDel.Click += new EventHandler(BtnorderDelete_Clicked);

            // Create your application here
        }

        private void listClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int ps = e.Position;
            idx = ps;
            Toast.MakeText(Application.Context, "Order has been selected ", ToastLength.Short).Show();


        }

        private void BtnorderDelete_Clicked(object sender, EventArgs e)
        {
            var dt = SQLClass.Instnce.getOrderList();
            Order register = dt[idx];

            int y = SQLClass.Instnce.Orderdel(register);
            if (y == 1)
            {
                Toast.MakeText(Application.Context, "Order is  Removed ", ToastLength.Short).Show();
            }

            List<String> dt1 = SQLClass.Instnce.getOrderList().Select(c =>c.Name+"-"+ c.Product + " - " + c.Price).ToList();

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