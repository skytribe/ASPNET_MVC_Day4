using EF_CodeFrist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_CodeFrist.Controllers
{
    public class MoviesController : Controller
    {
        private DataContext _dc = new DataContext();


        // GET: Movies
        public ActionResult IndexAll()
        {
            // Only show 0 status items
            var movies = from m in _dc.Movies
                 
                         select m;

            return View(movies.ToList());
        }   


        // GET: Movies
        public ActionResult Index()
        {
            // Only show 0 status items
            var movies = from m in _dc.Movies 
                         where m.DeleteStatus == 0
                         select m;

            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            // id is comming from the route controller argument
            // NOT The property from the movie class
            Movie movie = null;
            if (id.HasValue)
            {
                movie = _dc.Movies.Find(id);
                if (movie != null)
                {
                    return View(movie);
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _dc.Movies.Add(movie);
                _dc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            // 
            var movie = _dc.Movies.Find(id);
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                var original = _dc.Movies.Find(movie.Id);
                original.Name = movie.Name;
                original.Director = movie.Director;
                _dc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            var movie = _dc.Movies.Find(id);
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ActionName("Delete")]   // Requires this because both methods have same signature
        public ActionResult Delete(int? id, Movie movie)
        {
           var original = _dc.Movies.Find(movie.Id);
   
            original.DeleteStatus = 1;
            _dc.SaveChanges();  // This is the transactional changes
            return RedirectToAction("Index");


                //var original = _dc.Movies.Find(id);
                //_dc.Movies.Remove(original);
                //_dc.SaveChanges();
                //return RedirectToAction("Index");
      
           

        }
    }
}
