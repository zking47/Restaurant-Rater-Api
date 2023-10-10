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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            Restaurant? restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        //Async POST Endpoint
        [HttpPost]
        public async Task<IActionResult> PostRestaurant([FromBody] Restaurant request)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(request);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public async Task<IActionResult> PutRestaurant([FromBody] Restaurant request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Restaurant? restaurant = await _context.Restaurants.FindAsync(request.Id);
            if (restaurant is null)
            {
                return NotFound();
            }
            restaurant.Name = request.Name;
            restaurant.Location = request.Location;
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant is null)
            {
                return NotFound();
            }
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
