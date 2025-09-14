using Microsoft.OpenApi.Models;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityServerContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityServerContextConnection' not found.");

builder.Services.AddDbContext<IdentityServerContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<IdentityServerUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityServerContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Outentiek API", Version = "v1" });
});

var app = builder.Build();

app.MapControllers();
app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Outentiek API V1");
    });
}

app.Run();
