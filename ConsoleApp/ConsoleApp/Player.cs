namespace ConsoleApp
{
    public class Player
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Action> Actions { get; set; }
        public int Health { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
