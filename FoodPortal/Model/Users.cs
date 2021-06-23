﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodPortal.Model
{
   public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

    }
}