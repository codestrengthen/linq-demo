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
            using (var db = new RestaurantContext())
            {
                //JOIN & PROJECTION
                var query1 = from r in db.Restaurants
                             join s in db.Suburbs on r.SuburbID equals s.SuburbID
                             select new { RestaurantName = r.Name, r.Cuisine, Suburb = s.SuburbName };

                foreach (var item in query1)
                {
                    Console.WriteLine($"Name: {item.RestaurantName}, Cuisine: {item.Cuisine}, Suburb: {item.Suburb}");
                }

                //GROUP
                var query2 = from r in query1
                             group r by r.Suburb into g
                             select g;

                foreach (var resGroup in query2)
                {
                    Console.WriteLine($"Suburb: {resGroup.Key}");
                    foreach (var r in resGroup)
                    {
                        Console.WriteLine($"Name: {r.RestaurantName}, Cuisine: {r.Cuisine}");
                    }
                    Console.WriteLine();
                }

                //AGGREGATE
                var query3 = from r in db.Restaurants
                             join ra in db.Ratings on r.ResID equals ra.ResID
                             group r by r.ResID into g
                             select g;

                foreach (var resGroup in query3)
                {
                    Console.WriteLine("Restaurant: {0}", resGroup.Select(r => r.Name).First());
                    var restaurant = resGroup.First();
                    Console.WriteLine("Average Rating: {0:0.00}", restaurant.Ratings.Select(ra => ra.RatingValue).Average());
                    Console.WriteLine("Number of Ratings: {0}", restaurant.Ratings.Count());

                    Console.WriteLine();
                }
            }
        }
    }
}
