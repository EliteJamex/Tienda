using Microsoft.Extensions.DependencyInjection;
using Tienda_Prueba.Models;
using Tienda_Prueba.Interface;
using Tienda_Prueba.Repository;
using Tienda_Prueba.Servicios;
using Tienda_Prueba.Utilities;

var builder = WebApplication.CreateBuilder(args);

Usuario UsuarioIngreso;

// Add services to the container.
var config = builder.Configuration;
var cadenaConecSQL = new ConexionBD(config.GetConnectionString("SQL"));
builder.Services.AddSingleton(cadenaConecSQL);
builder.Services.AddSingleton< IProducto, ServicioProducto>();
builder.Services.AddSingleton<IFacturacion, ServicioFactura>();

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<RepositoryCarritoCompra>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
