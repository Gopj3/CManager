using System.Reflection;
using CManagerAPI.Configurations;
using CManagerAPI.Helpers.Middlewares;
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

builder.Services.AddControllers();

//Add services to the container.
builder.Services.AddScoped(c => new GlobalDataAccess(connectionString));

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

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

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();

