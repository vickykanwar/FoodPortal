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
    [Activity(Label = "Product")]
    public class Product : Activity
    {

        Button btnSubmit, btnBack;
        EditText txtProduct, txtPrice;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addProduct);
            // Create your application here
            //create the object of the button
            btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            btnSubmit.Click += new EventHandler(BtnSubmit_Clicked);

            //create the object of the button
            btnBack = FindViewById<Button>(Resource.Id.btnAdminBack);
            btnBack.Click += new EventHandler(BtnAdminBack_Clicked);

            txtProduct = FindViewById<EditText>(Resource.Id.TxtProduct);

            txtPrice = FindViewById<EditText>(Resource.Id.TxtPrice);

            SQLClass.Instnce.createTble();


        }

        private void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            ProductItems register = new ProductItems();
            register.Product = txtProduct.Text;
            register.Price = Convert.ToInt32(txtPrice.Text.ToString());
            int c = SQLClass.Instnce.insrt(register);
            if (c == 1)
            {
                Toast.MakeText(Application.Context, "Product Item is saved  ", ToastLength.Short).Show();
                txtProduct.Text = "";
                txtPrice.Text = "";
            }



        }

        private void BtnAdminBack_Clicked(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(AdminZone));
            StartActivity(intent);
        }
    }
}