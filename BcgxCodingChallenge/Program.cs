using BcgxCodingChallenge.DataAccess;
using BcgxCodingChallenge.DataAccess.Contexts;
using BcgxCodingChallenge.DataAccess.Repositories;
using BcgxCodingChallenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IShoppingService, ShoppingService>();
builder.Services.AddScoped<IWatchRepository, WatchRepository>();

var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["SqlConnectionString"];
builder.Services.AddDbContext<ShoppingContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

CreateDbIfNotExists(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ShoppingContext>();
            DatabaseConstructor.Create(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex.ToString());
        }
    }
}

public partial class Program { }

