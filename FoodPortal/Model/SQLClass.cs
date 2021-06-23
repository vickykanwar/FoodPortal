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
   public class SQLClass
    {
        private static SQLClass instance = new SQLClass();
        String db_Name = "FoodPortal.db";
        SQLiteConnection conn;
        public static SQLClass Instnce
        {
            get
            {

                return instance;
            }
        }
        public void createTble()
        {
            String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(path, db_Name));
            conn.CreateTable<ProductItems>();

        }

        public void createUserTble()
        {
            String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(path, db_Name));
            conn.CreateTable<Users>();

        }

        public void createOrderTble()
        {
            String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            conn = new SQLiteConnection(System.IO.Path.Combine(path, db_Name));
            conn.CreateTable<Order>();

        }


        public int insrt(ProductItems register)
        {
            int result = conn.Insert(register);
            return result;
        }

        public int Userinsrt(Users register)
        {
            int result = conn.Insert(register);
            return result;
        }
        
        public int Orderinsrt(Order register)
        {
            int result = conn.Insert(register);
            return result;
        }





        public List<ProductItems> getList()
        {

            List<ProductItems> data = conn.Table<ProductItems>().OrderByDescending(C => C.id).ToList();

            return data;
        }



        public List<Users> getUsersList()
        {

            List<Users> data = conn.Table<Users>().OrderByDescending(C => C.id).ToList();

            return data;
        }
        public List<Order> getOrderList()
        {

            List<Order> data = conn.Table<Order>().OrderByDescending(C => C.id).ToList();

            return data;
        }



        public int updte(ProductItems register)
        {

            int result = conn.Update(register);
            return result;
        }


        public int Usersupdte(Users register)
        {

            int result = conn.Update(register);
            return result;
        }


        public int Orderupdte(Users register)
        {

            int result = conn.Update(register);
            return result;
        }

        public int del(ProductItems register)
        {

            int result = conn.Delete(register);
            return result;
        }





        public int del(Users register)
        {

            int result = conn.Delete(register);
            return result;
        }

        public int Orderdel(Order register)
        {

            int result = conn.Delete(register);
            return result;
        }


    }
}