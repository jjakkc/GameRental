using MVCApp.Models;
using MVCApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (string.IsNullOrEmpty(sortBy))
        //        sortBy = "Release date";

        //    return Content($"pageIndex={pageIndex} sortBy={sortBy} hello world");
        //}

        // GET: /Game
        public ActionResult Index()
        {
            var viewModel = new GamesViewModel
            {
                Games = new List<GameModel>
                {
                    new GameModel { Title = "Final Fart 7" },
                    new GameModel { Title= "Hello Kitty Adventures" },
                    new GameModel { Title= "Simpsons Pool" },
                    new GameModel { Title= "Halo 5" },
                }
            };

            return View(viewModel);
        }

        public ActionResult Random()
        {
            var game = new GameModel() { Title = "Final Fart 7", Genre = "Action RPG" };
            var customers = new List<CustomerModel>
            {
                new CustomerModel(){ FirstName="Timmy", LastName="Jones"},
                new CustomerModel(){ FirstName="Jason", LastName="Glee"},
                new CustomerModel(){ FirstName="Sarah", LastName="Pooter"}
            };

            var viewModel = new RandomGameViewModel
            {
                Game = game,
                Customers = customers
            };

            //return Content(String.Format("Id={0}", contentID));
            return View(viewModel);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            string m = month.ToString();
            if (m.Length == 1)
                m = "0" + m;

            return Content($"{year} | {m}");
        }
    }
}