using ConsoleApp;
using Type = ConsoleApp.Type;

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    //if(db.Game.Any())
    //{
    //    return;
    //}

    // создаем два объекта User
    User user1 = new User { Name = "A"};
    User user2 = new User { Name = "B"};
    Game game = new Game { Status=Status.Created};
    Inventory wall1 = new Inventory { Type = Type.Wall, X = 1, Y = 1 };
    Inventory wall2 = new Inventory { Type = Type.Wall, X = 8, Y = 8 };


    // добавляем их в бд
    db.User.AddRange(user1, user2);
   // db.Inventory.AddRange(wall1, wall2);
    //db.Game.AddRange(game);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.User.ToList();
    Console.WriteLine("Users list:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name}");
    }
}