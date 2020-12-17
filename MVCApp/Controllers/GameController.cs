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
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrEmpty(sortBy))
                sortBy = "Release date";

            return Content($"pageIndex={pageIndex} sortBy={sortBy} hello world");
        }

        public ActionResult Random(int contentID)
        {
            return Content(String.Format("Id={0}", contentID));
        }
    }
}