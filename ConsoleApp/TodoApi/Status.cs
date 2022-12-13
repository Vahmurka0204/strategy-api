using ConsoleApp;

namespace TodoApi
{
    public class Status
    {
        public int Size { get; set; }

        public int Capacity { get; set; }

        public List<Player> Players { get; set; }

        public object[] Walls { get; set; }
    }
}