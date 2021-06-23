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
    [Activity(Label = "adLogin")]
    public class adLogin : Activity
    {

        Button btnLogin, btnBack;
        EditText txtEmail, txtPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.adminLogin);

            //create the object of the button
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += new EventHandler(BtnAdminLogin_Clicked);

            //create the object of the button
            btnBack = FindViewById<Button>(Resource.Id.btnBck);
            btnBack.Click += new EventHandler(BtnAdminBack_Clicked);

            txtEmail = FindViewById<EditText>(Resource.Id.edtUser);

            txtPassword = FindViewById<EditText>(Resource.Id.edtpssword);




            // Create your application here
        }

        private void BtnAdminBack_Clicked(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void BtnAdminLogin_Clicked(object sender, EventArgs e)
        {
            String usr = txtEmail.Text.ToString();
            String pwd = txtPassword.Text.ToString();
            if (usr.Equals("admin@gmail.com") && pwd.Equals("12345"))
            {
                Intent intent = new Intent(this, typeof(AdminZone));
                StartActivity(intent);
            }
            else {
                Toast.MakeText(Application.Context, "Check User Name  and  Password", ToastLength.Short).Show();
            }
        }
    }
}