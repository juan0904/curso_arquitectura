using Microsoft.Extensions.Hosting;
using Northwind.ConsoleApp.Services;
using Northwind.Writers;
using NorthWind.Entities.Interfaces; 
using Microsoft.Extensions.DependencyInjection;

var Builder = Host.CreateApplicationBuilder();
Builder.Services.AddConsoleWriter();
Builder.Services.AddDebugWriter();
Builder.Services.AddFileWriter();
Builder.Services.AddSingleton<AppLogger>();
Builder.Services.AddSingleton<ProductService>();
using var AppHost = Builder.Build();


IUserActionWriter Writer = new DebugWriter();

AppLogger Logger = new AppLogger(Writer);
Logger.WriteLog("Application started.");

ProductService Service = new ProductService(Writer);
Service.Add("Demo", "Azucar refinada");