using EcommerceBackend.Core.Repositories;
using EcommerceBackend.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddCors(options => options.AddPolicy("AllowAll", builder => builder
                                                                        .AllowAnyHeader()
                                                                        //.AllowAnyOrigin()
                                                                        .WithOrigins("https://localhost:3000")
                                                                        .AllowAnyMethod()
                                                                        .AllowCredentials()
                                                                        .SetIsOriginAllowed(hostName => true))
                                //options.AddPolicy("AllowReactApp",
                                //        builder => builder
                                //        .WithOrigins("https://localhost:3000")
                                //        .AllowAnyMethod()
                                //        .WithHeaders("Authorization", "Content-Type", "access-control-allow-origin")
                                //        .AllowCredentials()
                                //        .WithExposedHeaders("Authorization")
                                //    );
    );

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
})
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
