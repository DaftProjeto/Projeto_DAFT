using Projeto_DAFT;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(
    opt => opt.UseSqlServer("Server=DESKTOP-AIV65GI\\SQLEXPRESS;Database=PROJETO_TCC_ANTEPROJETO_INICIAL;Trusted_Connection=True;")
    );

builder.Services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", option =>
{
    option.LoginPath = "/Login/Entrar";
    option.AccessDeniedPath = "/";
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
