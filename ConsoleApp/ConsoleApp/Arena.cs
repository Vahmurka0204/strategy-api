namespace ConsoleApp
{
    public class Arena
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
