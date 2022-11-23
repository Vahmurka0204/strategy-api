namespace ConsoleApp
{
    public enum Value
    {
        Empty,
        Left,
        Right,
        Up,
        Down
    }
    public class Action
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int Round { get; set; }
        public int Index { get; set; }
        public Value Value { get; set; }
    }
}
