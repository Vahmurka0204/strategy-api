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
    User user1 = new User { Name = "A" };
    User user2 = new User { Name = "B" };
    Inventory wall1 = new Inventory { Type = Type.Wall, X = 1, Y = 1 };
    Inventory wall2 = new Inventory { Type = Type.Wall, X = 8, Y = 8 };
    Inventory spawn1 = new Inventory { Type = Type.Spawn, X = 0, Y = 0 };
    Inventory spawn2 = new Inventory { Type = Type.Spawn, X = 9, Y = 9 };

    Arena arena = new Arena { Name = "Arena 2000", Height = 10, Width = 10 };

    arena.Inventories.Add(wall1);
    arena.Inventories.Add(wall2);
    arena.Inventories.Add(spawn1);
    arena.Inventories.Add(spawn2);

    Game game = new Game { Status = Status.Created, Arena = arena };



    // добавляем их в бд
    db.User.AddRange(user1, user2);
    db.Game.AddRange(game);
    db.SaveChanges();
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();