using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using crudelicious.Models;

namespace crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private CrudeliciousContext db;
        public HomeController(CrudeliciousContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            // Get all Dishes
            List<Dish> AllDishes = db.Dishes.ToList();

            // Get the 5 most recently added Dishes
            // List<Dish> MostRecent = db.Dishes
            //     .OrderByDescending(u => u.CreatedAt)
            //     .Take(5)
            //     .ToList();
            return View(AllDishes);
        }
        
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateDish(Dish newDish)
        {
            // We can take the Dish object created from a form submission
            // And pass this object to the .Add() method
            db.Dishes.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("update/{dishId}")]
        public IActionResult UpdateDish(int dishId)
        {
            // Query for matching Dish to update
            Dish RetrievedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            // Then we may modify properties of this tracked model object
            RetrievedDish.Name = "New name";
            RetrievedDish.UpdatedAt = DateTime.Now;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            // Query for matching Dish to update
            Dish RetrievedDish = db.Dishes.SingleOrDefault(dish => dish.DishId == dishId);

            // Then pass the object we queried for to .Remove() on Users
            db.Dishes.Remove(RetrievedDish);

            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
