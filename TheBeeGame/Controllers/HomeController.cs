using System.Web.Mvc;
using TheBeeGame.Models;

namespace TheBeeGame.Controllers
{
    public class HomeController : Controller
    {
        BeeGame game;
        GameSettings settings;

        public ActionResult Index()
        {
            game = new BeeGame();
            settings = new GameSettings(new GameRule(0, 1, 100, 8), new GameRule(0, 5, 75, 10), new GameRule(0, 8, 50, 12));

            game.Start(settings);

            Session["game"] = game;
            Session["settings"] = settings;

            return View(game);
        }

        public ActionResult HitBee()
        {
            game = (BeeGame)Session["game"];

            if (game.IsPlaying)
            {
                game.HitBee(game.Hive);
            }

            return View("Index", game);
        }

        public ActionResult StartGame()
        {
            game = (BeeGame)Session["game"];

            settings = (GameSettings)Session["settings"];
            game.Start(settings);

            return View("Index", game);
        }
    }
}
