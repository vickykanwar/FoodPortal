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

namespace FoodPortal
{
    [Activity(Label = "AdminZone")]
    public class AdminZone : Activity
    {
        Button btnAddProduct, btnManageProduct, btnAllOrder;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adminDashboard);

            btnAddProduct = FindViewById<Button>(Resource.Id.btnAddProduct);
            btnAddProduct.Click += new EventHandler(BtnaddProduct_Clicked);

            btnManageProduct = FindViewById<Button>(Resource.Id.btnManageProduct);
            btnManageProduct.Click += new EventHandler(BtnReg_Clicked);

            btnAllOrder = FindViewById<Button>(Resource.Id.btnallOrders);
            btnAllOrder.Click += new EventHandler(BtnallOrder_Clicked);


            // Create your application here
        }

        private void BtnaddProduct_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Product));
            StartActivity(intent);

        }

        private void BtnReg_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ManageProduct));
            StartActivity(intent);
        }

        private void BtnallOrder_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ViewOrder));
            StartActivity(intent);
        }
    }
}