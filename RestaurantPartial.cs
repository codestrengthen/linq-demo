using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    public partial class Restaurant : IEquatable<Restaurant>
    {
        public bool Equals(Restaurant otherRestaurant)
        {
            if (otherRestaurant is null) return false;

            if (Object.ReferenceEquals(this, otherRestaurant)) return true;

            return Name.Equals(otherRestaurant.Name) && SuburbID.Equals(otherRestaurant.SuburbID);
        }

        public override int GetHashCode()
        {
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashSuburbID = SuburbID.GetHashCode();
            return hashName ^ hashSuburbID;
        }
    }
}
