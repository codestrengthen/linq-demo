using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db  = new RestaurantContext())
            {
                //var restaurants = from r in db.Restaurants
                //                  select r;

                //var restaurants = from r in db.Restaurants
                //                  where r.Cuisine == "Chinese"
                //                  select r;

                var restaurants = from r in db.Restaurants
                                  orderby r.Cuisine
                                  select r;

                foreach (var res in restaurants)
                {
                    Console.WriteLine($"ID: {res.ResID}, Name: {res.Name}, Cuisine: {res.Cuisine}");
                }
            }
        }
    }
}
