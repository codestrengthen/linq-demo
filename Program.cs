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
           using(var db = new RestaurantContext())
           {
                var givenRatings = db.Ratings.Select(ra => ra.RatingValue).Distinct();
                foreach(var rv in givenRatings)
                {
                    Console.WriteLine(rv);
                }

                Console.WriteLine("----------------------");

                var distinctRestaurants = db.Restaurants.AsEnumerable().Distinct();
                foreach(var r in distinctRestaurants)
                {
                    Console.WriteLine(r.Name);
                }

                Console.WriteLine("----------------------");


                var firstRestaurant = db.Restaurants.Where(r => r.Name == "Test").FirstOrDefault();
                //Console.WriteLine(firstRestaurant.Name);

                Console.WriteLine("----------------------");

                var restaurants = db.Restaurants;

                restaurants.OrderBy(r => r.ResID).Skip(3).ToList()
                           .ForEach(r => Console.WriteLine($"{r.ResID} {r.Name}"));

                Console.WriteLine("----------------------");

                restaurants.Take(3).ToList()
                           .ForEach(r => Console.WriteLine($"{r.ResID} {r.Name}"));

                Console.WriteLine("----------------------");

                restaurants.OrderBy(r => r.ResID).Skip(3).Take(3).ToList()
                           .ForEach(r => Console.WriteLine($"{r.ResID} {r.Name}"));
            }
        }
    }
}
