using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Data
{
    public class RatingEdit
    {
        public double Score { get; set; }
        public int RestaurantId { get; set; }
    }
}