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
    [Activity(Label = "clLogin")]
    public class clLogin : Activity
    {
        Android.Widget.EditText txt;
        Android.Widget.EditText txtpwd;
        Android.Widget.Button btn, btnBck;

        List<String> dtUser;

        List<String> dtPwd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.customerLogin);
            // Create your application here


            txt = FindViewById<EditText>(Resource.Id.edtUser);

            txtpwd = FindViewById<EditText>(Resource.Id.edtpssword);

            SQLClass.Instnce.createUserTble();


            btn = FindViewById<Button>(Resource.Id.btnLogin);
            btn.Click += new EventHandler(BtnclLogin_Clicked);

            dtUser = SQLClass.Instnce.getUsersList().Select(c => c.Email).ToList();
            dtPwd = SQLClass.Instnce.getUsersList().Select(c => c.Password).ToList();


            btnBck = FindViewById<Button>(Resource.Id.btnBck);
            btnBck.Click += new EventHandler(BtnclBck_Clicked);




        }

        private void BtnclLogin_Clicked(object sender, EventArgs e)
        {
            int ct = 0;

            String usr = txt.Text.ToString();
            String pwd = txtpwd.Text.ToString();

            for (int x = 0; x < dtUser.Count; x++)
            {
                String h = dtUser[x].ToString();
                String i = dtPwd[x].ToString();

                //  Toast.MakeText(Application.Context, "Check User Name  and  Password", ToastLength.Short).Show();

                if (usr.Equals(h) && pwd.Equals(i))
                {
                    Intent intent = new Intent(this, typeof(Customer_ViewProduct));
                    intent.PutExtra("Name", usr);
                    StartActivity(intent);
                    ct++;
                    break;

                }

            }
            //btn.Text = "In====" + usr;

            if (ct == 0)
            {
                Toast.MakeText(Application.Context, "Check User Name  and  Password", ToastLength.Short).Show();
            }



        }

        private void BtnclBck_Clicked(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);

        }
    }
}