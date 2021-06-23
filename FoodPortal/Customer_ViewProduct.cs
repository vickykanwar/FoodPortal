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
    [Activity(Label = "Customer_ViewProduct")]
    public class Customer_ViewProduct : Activity
    {
        ListView lst;
        Android.Widget.Button btnConfirm, btnBack;
        int idx = -1;
        ArrayAdapter usr;
        String name = "";

        List<String> dtProduct;

        List<int> dtPrice;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CustomerViewProduct);


            SQLClass.Instnce.createTble();


            lst = FindViewById<ListView>(Resource.Id.lstProduct);


            List<String> dt = SQLClass.Instnce.getList().Select(c => c.Product + "-" + c.Price).ToList();

             dtProduct= SQLClass.Instnce.getList().Select(c => c.Product).ToList();
            dtPrice = SQLClass.Instnce.getList().Select(c => c.Price).ToList();


            usr = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, dt);

            lst.Adapter = usr;
            lst.ItemClick += listClick;
            // Create your application here


            btnConfirm = FindViewById<Button>(Resource.Id.btnContinue);
            btnConfirm.Click += new EventHandler(BtnContinue_Clicked);

            btnBack = FindViewById<Button>(Resource.Id.btnBck);
            btnBack.Click += new EventHandler(BtnExit_Clicked);

          name = Intent.GetStringExtra("Name");


            SQLClass.Instnce.createOrderTble();

            // Create your application here
        }

        private void listClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int ps = e.Position;
            idx = ps;
            Toast.MakeText(Application.Context, "Product is Selected  ", ToastLength.Short).Show();


        }

        private void BtnContinue_Clicked(object sender, EventArgs e)
        {
            Order register = new Order();
            register.Name = name;
            
            register.Product=dtProduct[idx].ToString();
            register.Price=dtPrice[idx];
            
            int c = SQLClass.Instnce.Orderinsrt(register);
            if (c == 1)
            {
                Toast.MakeText(Application.Context, "Order is Placed ", ToastLength.Short).Show();
               

            }


        }

        private void BtnExit_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}