using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Data
{
    public class Rating
    {
        public int Id {get; set;}
        public double Score { get; set; }
        public int RestaurantId { get; set; }
    }
}