﻿using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Action> Action { get; set; } = null!;
        public DbSet<Arena> Arena { get; set; } = null!;
        public DbSet<Game> Game { get; set; } = null!;
        public DbSet<Inventory> Inventory { get; set; } = null!;
        public DbSet<Player> Player { get; set; } = null!;

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=strategydb;Username=postgres;Password=123456");
        }
    }
}
