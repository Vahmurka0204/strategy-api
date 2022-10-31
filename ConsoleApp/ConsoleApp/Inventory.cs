namespace ConsoleApp
{
    public enum Type
    {
        Wall,
        Spawn
    }
    public class Inventory
    {
        public int Id { get; set; }
        public int ArenaId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Type Type { get; set; }

    }
}
