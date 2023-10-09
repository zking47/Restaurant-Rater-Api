using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Data
{
    public class Restaurant
    {
        public int Id {get; set;}
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}