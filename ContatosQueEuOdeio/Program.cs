using ContatosQueEuOdeio.Models;
using ContatosQueEuOdeio.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContatosContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ContatosDatabase")
    )
);

//builder.Services.AddScoped<IClienteService, DBContextCliente>();
builder.Services.AddScoped<IClienteService, DapperCliente>();
builder.Services.AddScoped<IContatoService, DBContextContato>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{idCliente?}");

app.Run();
