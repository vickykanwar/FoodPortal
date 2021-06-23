using Android.App;
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
   public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String Name { get; set; }

        public String Product { get; set; }
        public int Price { get; set; }
    }
}