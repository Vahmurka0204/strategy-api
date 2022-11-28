﻿namespace ConsoleApp
{
    public class Player
    {
        public int Id { get; set; }
        public List<Action> Actions { get; set; } = new List<Action>();
        public int Health { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
