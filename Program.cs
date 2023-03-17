global using Microsoft.EntityFrameworkCore;
global using TestWasm.Shared;
global using TestWasm.Server.Data;
global using TestWasm.Server.Services.ProductService;
global using TestWasm.Shared.ViewModel;
using Microsoft.AspNetCore.ResponseCompression;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(
    option =>
    {
        option.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
    });

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer(); //swager
builder.Services.AddSwaggerGen(); //swager

builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

app.UseSwaggerUI(); //swagger

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger(); //swagger
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

