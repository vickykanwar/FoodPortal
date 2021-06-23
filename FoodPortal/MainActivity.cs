using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace FoodPortal
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnAdmin, btnCustomer, btnRegister;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
        
            SetContentView(Resource.Layout.activity_main);
            

            btnAdmin = FindViewById<Button>(Resource.Id.btnAdminLogin);
            btnAdmin.Click += new EventHandler(BtnAdmin_Clicked);

            btnRegister = FindViewById<Button>(Resource.Id.btnNewRegister);
            btnRegister.Click += new EventHandler(BtnReg_Clicked);

            btnCustomer = FindViewById<Button>(Resource.Id.btnCustomerLogin);
            btnCustomer.Click += new EventHandler(BtnClient_Clicked);


        }

        private void BtnClient_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(clLogin));
            StartActivity(intent);

        }

        private void BtnAdmin_Clicked(object sender, EventArgs e)
        {
           Intent intent = new Intent(this, typeof(adLogin));
            StartActivity(intent);

        }

        private void BtnReg_Clicked(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(SignUp));
            StartActivity(intent);
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}