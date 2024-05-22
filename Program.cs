using Microsoft.EntityFrameworkCore;
using D1_Training.Data;
using D1_Training.Interfaces;
using D1_Training.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;
using D1_Training.Validations.CustomValidations;
// using Westwind.AspNetCore.LiveReload;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString, o => o.CommandTimeout(600))
);



// Add services to the container.
builder.Services.AddControllersWithViews();

// repository service
builder.Services.AddSingleton<DapperDbContext>();
builder.Services.AddTransient<IMahasiswaRepository, MahasiswaRepository>();
builder.Services.AddTransient<IMasterTARepository, MasterTARepository>();


// register auto validation
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//validator service
builder.Services.AddScoped<MahasiswaCustomValidation>();
// register auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
