using Application;
using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Application.Aggregates.CarBrandAggregate.Queries;
using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.Common.Interfaces;
using Domain.Common;
using CarHireInfrastructure.Data;
using CarHireInfrastructure.Data.EfCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI;
using WebAPI.Model;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Application.Repositories;
using CarHireInfrastructure.Repositories.UserRepos;
using Domain.Interfaces;
using CarHireInfrastructure.Abstractions;
using mailinator_csharp_client;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var sqliteConnectionString = builder.Configuration.GetConnectionString("SqliteConnection");


var provider = builder.Configuration.GetValue("Provider", "SqlServer");

builder.Services.AddDbContext<ApplicationDbContext>(options => _ = provider switch
{
    "Sqlite" => options.UseSqlite(sqliteConnectionString,
    x => x.MigrationsAssembly(@"CarHireInfrastructure.SqliteMigrations")),

    "SqlServer" => options.UseSqlServer(connectionString,
    x => x.MigrationsAssembly(@"CarHireInfrastructure.SqlServerMigrations")),

    _ => throw new Exception($"Unsupported provider: {provider}")
});


builder.Services.AddDbContext<WebIdentityContext>(options => _ = provider switch
{
    "Sqlite" => options.UseSqlite(sqliteConnectionString,
    x => x.MigrationsAssembly(@"CarHireInfrastructure.SqliteMigrations")),

    "SqlServer" => options.UseSqlServer(connectionString,
    x => x.MigrationsAssembly(@"CarHireInfrastructure.SqlServerMigrations")),

    _ => throw new Exception($"Unsupported provider: {provider}")
});


builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "CarHire_";
});

builder.Services.AddMediatR(typeof(CreateCarBrandCommand).Assembly);
builder.Services.AddMediatR(typeof(CreateCarHireCommand).Assembly);
builder.Services.AddMediatR(typeof(GetCarBrandsQuery).Assembly);


builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(IApplicationDbContext), typeof(ApplicationDbContext));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<WebIdentityContext>();

builder.Services.AddScoped(typeof(IRepository<,>), typeof(EfCoreRepository<,>));





builder.Services.AddBlazorServices();

builder.Services.AddHealthChecks();

// Add services to the container.
builder.Services.AddControllers();



var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
{
o.AssumeDefaultVersionWhenUnspecified = true;
o.DefaultApiVersion = new ApiVersion(1, 0);
o.ReportApiVersions = true;
o.ApiVersionReader = ApiVersionReader.Combine(
    new QueryStringApiVersionReader("api-version"),
    new HeaderApiVersionReader("X-Version"),
    new MediaTypeApiVersionReader("ver"));
});

// Add JWT token logic
{
    var services = builder.Services;

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
}


var appSettings = new AppSettings();
builder.Configuration.Bind(nameof(AppSettings), appSettings);

//Email sender setup
builder.Services.AddTransient<IEmailSender>(provider =>
{
    return new EmailSender(appSettings.MailinatorApiToken, appSettings.MailinatorDomain);
});


var jwtSettings = new JWTSettings();
builder.Configuration.Bind(nameof(JWTSettings), jwtSettings);


// Add JWT configuration
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});


var securityScheme = new OpenApiSecurityScheme()
{
    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    Reference = new OpenApiReference
    {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
    }
};



var securityReq = new OpenApiSecurityRequirement
{
    { securityScheme, new[] { "Bearer" } }
};


var contact = new OpenApiContact()
{
    Name = "Sertac Topaloglu",
    Url = new Uri("https://sites.google.com/site/sertactopaloglu/home")
};



var info = new OpenApiInfo()
{
    Version = "v1",
    Title = "Car hire API",
    Description = "JWT Authentication in Minimal API",
    TermsOfService = new Uri("https://sites.google.com/site/sertactopaloglu/home"),
    Contact = contact
};

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});



builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();





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

app.MapHealthChecks("/health");

app.Run();

public partial class Program { }