using MVCApp.Models;
using MVCApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class GameController : Controller
    {
        private MyDbContext _context;

        public GameController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }
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
            //var games = GetGames();
            var games = _context.Games.Include(game => game.Genre).ToList();

            return View(games);
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(g => g.Genre).FirstOrDefault();

            if(game == null)
            {
                return HttpNotFound();
            }

            return View(game);
        }

        // GET: Game/Random
        public ActionResult Random()
        {
            var game = new GameModel() { Title = "Final Fart 7" };
            game.Genre = new Genre { Name = "Action RPG" };
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

        // GET: Game/released/2000/12
        // doesn't work GET: Game/byreleasedate because attribute route?
        [Route("game/released/{year:regex(\\d{4}):max(2020)}/{month:regex(\\d{1,2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            string m = month.ToString();
            if (m.Length == 1)
                m = "0" + m;

            return Content($"{year} | {m}");
        }

        private IEnumerable<GameModel> GetGames()
        {
            return new List<GameModel>
            {
                new GameModel { Title = "Final Fart 7" },
                new GameModel { Title= "Hello Kitty Adventures" },
                new GameModel { Title= "Simpsons Pool" },
                new GameModel { Title= "Halo 5" },
            };
        }
    }
}