using Microsoft.AspNetCore.Mvc;
using ConsoleApp;

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
            var wallsData = _context.Inventory.ToList();

            object[] walls = new object[wallsData.Count];
            int i = 0;
            foreach (var wall in wallsData)
            {
                walls[i++] = new object[] {wall.X, wall.Y};
            }

            return new Status() {
                Size=10,
                Capacity=2,
                Players = new object[0],
                Walls = walls
            };
        }

        [Route("join")]
        [HttpPost]
        public void Join()
        {
           
        }

        [Route("leave")]
        [HttpPost]
        public void Leave()
        {

        }

        [Route("submit")]
        [HttpPost]
        public void Submit()
        {

        }
    }
}