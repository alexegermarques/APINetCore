using ApiNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IStockService, StockServiceImpl>();
builder.Services.AddTransient<ICommentService, CommentServiceImpl>();

var connectionString = builder.Configuration.GetConnectionString("DevConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();