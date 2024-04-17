using Microsoft.EntityFrameworkCore;
using RazorPagesPizza.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using RazorPagesPizza.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RazorPagesPizzaAuthConnection");
builder.Services.AddDbContext<RazorPagesPizzaAuth>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<RazorPagesPizzaUser>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddEntityFrameworkStores<RazorPagesPizzaAuth>();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailSender, EmailSender>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
