using CQRS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* согласно документации библиотеки, зарегистрируем ее в контейнере зависимостей.*/
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

/*необходимо зарегистрировать наше хранилище.*/
builder.Services.AddSingleton<ProductStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
