using Microsoft.AspNetCore.Mvc;
using ConsoleApp;
using Type = ConsoleApp.Type;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private readonly ApplicationContext _context;

        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("state")]
        [HttpGet]
        public Status Get()
        {
            var game = _context.Game.First();

            var inventoriesData = game.Arena.Inventories.ToList();
            var wallsData = inventoriesData.FindAll(e => e.Type == Type.Wall);
            var spawnData = inventoriesData.FindAll(e => e.Type == Type.Spawn);


            object[] walls = new object[wallsData.Count];
            int i = 0;

            foreach (var wall in wallsData)
            {
                walls[i++] = new object[] {wall.X, wall.Y};
            }

            return new Status() {
                Size=game.Arena.Width,
                Capacity=spawnData.Count,
                Players = game.Players,
                Walls = walls

            };
        }

        [Route("join")]
        [HttpPost]
        public PlayerOutput Join(Credentials credentials)
        {
            var game = _context.Game.First();
            if (credentials.id == null)
            {
                credentials.id = game.Players.Count + 1;
            }
            var user = _context.User.First(e=>e.Id==credentials.id);
            var inventoriesData = game.Arena.Inventories.ToList();
            var spawnData = inventoriesData.FindAll(e => e.Type == Type.Spawn);
            var players = game.Players.ToList();
            var spawnForPlayer = spawnData[players.Count];
            var player = new Player() { X = spawnForPlayer.X, Y = spawnForPlayer.Y, Health = 3 };
            user.Players.Add(player);
            game.Players.Add(player);
            _context.Game.Update(game);
            _context.User.Update(user);
            _context.SaveChanges();
            return new PlayerOutput() { Health = player.Health, Name = user.Name, X= player.X, Y=player.Y, Id = player.Id };
        }

        [Route("leave")]
        [HttpPost]
        public Credentials Leave(Credentials credentials)
        {
            var game = _context.Game.First();
            var player = game.Players.Find(e => e.Id == credentials.id);
            game.Players.Remove(player);
            _context.Game.Update(game);
            _context.SaveChanges();
            return new Credentials();
        }

        [Route("submit")]
        [HttpPost]
        public void Submit()
        {

        }
    }
}