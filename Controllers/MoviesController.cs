using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {


        public ActionResult Index()
        {

            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shrek"},
                new Movie {Id = 2, Name = "Wall-e"},
            };

            var viewModel = new AllMoviesViewModel()
            {
                Movies = movies
            };


            return View(viewModel);

        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            
            return View(viewModel);



            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});

            //return View(movie);

        }

        public ActionResult Edit(int? id, int? pageIndex, string sortBy)
        {

            if (!id.HasValue)
            {
                return new EmptyResult();
            }
            else
            {
                return Content("id=" + id);
            }
            
        }

        // movies
        

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }




        public ActionResult Details(int? id)
        {

            if (!id.HasValue)
            {

                return RedirectToAction("Index");
            }



            if (id.Value == 1)
            {
                var movie = new MovieDetailsViewModel() { Id = 1, Name = "Shrek" };

                return View(movie);

            }

            if (id.Value == 2)
            {

                var movie = new MovieDetailsViewModel() { Id = 2, Name = "Wall-e" };

                return View(movie);
            }


            return HttpNotFound();




        }

    }
}