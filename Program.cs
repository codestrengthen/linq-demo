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
                var excellentRestaurnts = db.Restaurants.Where(r => r.Ratings.All(ra => ra.RatingValue >= 4)
                                                                && r.Ratings.Count() > 0);
                foreach(var r in excellentRestaurnts)
                {
                    Console.WriteLine(r.Name);
                }

                Console.WriteLine("-----------------------");

                var strictCustomers = db.Customers.Where(c => c.Ratings.Any(ra => ra.RatingValue <= 2));

                foreach (var c in strictCustomers)
                {
                    Console.WriteLine(c.CustomerName);
                }

                Console.WriteLine("-----------------------");

                var checkCuisine = excellentRestaurnts.Select(r => r.Cuisine).Contains("Chinese");
                Console.WriteLine(checkCuisine);
            }
        }
    }
}
