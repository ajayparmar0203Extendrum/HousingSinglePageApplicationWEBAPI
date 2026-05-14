using AutoMapper;
using HousingSinglePageApplicationWEBAPI.Data;
using HousingSinglePageApplicationWEBAPI.Helpers;
using HousingSinglePageApplicationWEBAPI.Interfaces;
using HousingSinglePageApplicationWEBAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;




var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("MyDBConnection");
builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPhotoService, PhotoService>();

var secretKey = builder.Configuration["JwtSettings:Key"];

var key = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(secretKey));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter JWT token like: Bearer {your token}"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),

        ValidateIssuer = false,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],

        ValidateAudience = false,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],

        ValidateLifetime = true,


        ClockSkew = TimeSpan.FromMinutes(30)
    };
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHsts();
app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
