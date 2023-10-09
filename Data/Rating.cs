using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRaterAPI.Data
{
    public class Rating
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [Range(0, 5)]
        public double Score { get; set; }

        [Required]
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
    }
}