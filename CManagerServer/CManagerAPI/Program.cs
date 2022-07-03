using System.Reflection;
using CManagerAPI.Configurations;
using CManagerApplication;
using CManagerApplication.Common.Helpers;
using CManagerData;
using CManagerData.DataAccess;
using CManagerData.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Database");
var appContext = new ApplicationDbContext(connectionString);

builder.Services.AddControllers();

//Add services to the container.
builder.Services.AddSingleton<ApplicationDbContext>(x => appContext);
builder.Services.AddScoped<GlobalDataAccess>(c => new GlobalDataAccess(appContext));

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<JwtHelper>();

builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.ConfigureJWT(builder.Configuration.GetSection("JWTSettings"));

builder.Services.AddCors(options => options.AddDefaultPolicy(
    x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod())
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterRequestHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();

