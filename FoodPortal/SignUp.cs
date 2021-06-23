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
    [Activity(Label = "SignUp")]
    public class SignUp : Activity
    {

        Button btnSubmit, btnLogin;
        EditText txtEmail, txtPassword;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Register);

            btnSubmit = FindViewById<Button>(Resource.Id.btnSign);
            btnSubmit.Click += new EventHandler(BtnSubmit_Clicked);

            //create the object of the button
            btnLogin = FindViewById<Button>(Resource.Id.btnLog);
            btnLogin.Click += new EventHandler(BtnCustomerLogin_Clicked);

            txtEmail = FindViewById<EditText>(Resource.Id.TxtEmail);

            txtPassword = FindViewById<EditText>(Resource.Id.TxtPwd);

            SQLClass.Instnce.createUserTble();


            // Create your application here
        }

        private void BtnCustomerLogin_Clicked(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(clLogin));
            StartActivity(intent);
        }

        private void BtnSubmit_Clicked(object sender, EventArgs e)
        {
            Users register = new Users();
            register.Email = txtEmail.Text;
            register.Password = txtPassword.Text.ToString();
            int c = SQLClass.Instnce.Userinsrt(register);
            if (c == 1)
            {
                Toast.MakeText(Application.Context, "Users is Registered  ", ToastLength.Short).Show();
                txtEmail.Text = "";
                txtPassword.Text = "";
            }


        }
    }
}