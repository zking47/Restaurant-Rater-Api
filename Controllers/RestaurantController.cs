using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI.Data;

namespace RestaurantRaterAPI.Controllers;
[ApiController]
[Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }
        // Async GET Endpoint
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        public async Task<IActionResult> GetRestaurantById(int id)
        {
            Restaurant? restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
    }
