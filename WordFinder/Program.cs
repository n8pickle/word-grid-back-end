using Database;
using WordFinder.Hubs;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["DbConnectionString"];

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddEntityFrameworkMySql().AddDbContext<MyDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(10, 4, 13))));
builder.Services.AddTransient<WordCheckerRepo, WordCheckerRepo>();

builder.Services.AddCors(options =>
	{
		options.AddPolicy("CorsPolicy",
			builder =>
			{
			    builder
				    .AllowAnyMethod()
				    .AllowAnyHeader()
				    .SetIsOriginAllowed(__ => true)
				    .AllowCredentials();
			});
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


app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<WordHub>("/wordHub");
app.Run();
