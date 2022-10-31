using ConsoleApp;

using (ApplicationContext db = new ApplicationContext())
{
    // создаем два объекта User
    User user1 = new User { Name = "Bob"};
    User user2 = new User { Name = "Alex"};

    // добавляем их в бд
    db.User.AddRange(user1, user2);
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