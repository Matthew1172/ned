using Microsoft.EntityFrameworkCore;
using ned_task.Models;
using Syncfusion.Blazor;

//create the blazor web application with provided command line args
var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//Register syncfusion service for SF components like datagrid.
builder.Services.AddSyncfusionBlazor();

//register user interface as scope service so blazor app can use it
builder.Services.AddScoped<MyUserServiceInterface, MyUserService>();

//configure db context with connection string from hidden json file with sensitive info. Register as scope service so razor pages can connect.
builder.Services.AddDbContext<MyUserContext>(o =>
                o.UseSqlServer(builder.Configuration.GetConnectionString("MyUserConnection")));

//build blazor web application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
