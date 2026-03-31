using Microsoft.AspNetCore.Mvc;
using GameApp.Models;
using System.Text.Json;

namespace GameApp.Controllers
{
    public class GameController : Controller
    {
        // For simplicity, we store the state in a Session
        private GameModel GetGameState()
        {
            var sessionData = HttpContext.Session.GetString("GameState");
            return sessionData == null ? new GameModel() : JsonSerializer.Deserialize<GameModel>(sessionData);
        }

        private void SaveGameState(GameModel model)
        {
            HttpContext.Session.SetString("GameState", JsonSerializer.Serialize(model));
        }

        public IActionResult Index()
        {
            var model = GetGameState();
            return View(model);
        }

        [HttpPost]
        public IActionResult Attack()
        {
            var model = GetGameState();
            if (!model.IsGameOver) model.Attack();
            SaveGameState(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Heal()
        {
            var model = GetGameState();
            if (!model.IsGameOver) model.Heal();
            SaveGameState(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reset()
        {
            HttpContext.Session.Remove("GameState");
            return RedirectToAction("Index");
        }
    }
}