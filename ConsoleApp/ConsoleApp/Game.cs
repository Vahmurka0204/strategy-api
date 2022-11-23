namespace ConsoleApp
{
    public enum Status
    {
        Created,
        Started,
        Finished
    }
    public class Game
    {
        public int Id { get; set; }
        public int ArenaId { get; set; }
        public Arena Arena { get; set; }
        public Status Status { get; set; }
        public int Round { get; set; }
        public List<Player> Players { get; set; }
    }
}
