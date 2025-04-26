using CityInfo.API;
using CityInfo.API.Services;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json.Serialization;
using Serilog;
using CityInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// builder.Logging.ClearProviders();
// builder.Logging.AddConsole();
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})  .AddNewtonsoftJson(setupAction =>
{
    setupAction.SerializerSettings.ContractResolver =
        new CamelCasePropertyNamesContractResolver();
})
    .AddXmlDataContractSerializerFormatters();
;
    builder.Services.AddProblemDetails();
// builder.Services.AddProblemDetails(options =>
// {
//     options.CustomizeProblemDetails = ctx =>
//     {
//         ctx.ProblemDetails.Extensions.Add("AdditionalInfo","you did me WRONG!");
//         ctx.ProblemDetails.Extensions.Add("server", Environment.MachineName);
//     };
// });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("CityInfoApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Input a valid token to access this API"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "CityInfoApiBearerAuth"
                }
            }, new List<string>()
        }
    });
});
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddTransient<IMailService, LocalMailService>();
}
else
{
    builder.Services.AddTransient<IMailService, CloudMailService>();
}
builder.Services.AddSingleton<CitiesDataStore>();
builder.Services.AddDbContext<CityInfoContext>(dbContextOptions
=> dbContextOptions.UseSqlite(builder.Configuration["ConnectionString:CityInfoDBConnectionString"]));

builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]))
        };
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AllowedCities", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("city", new[]{
                "Antwerp", "New York City", "Paris"});
        });
    });
    builder.Services.AddApiVersioning(setupAction =>
    {
        setupAction.ReportApiVersions = true;
        setupAction.AssumeDefaultVersionWhenUnspecified = true;
        setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    }).AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        setupAction.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "CityInfo API v1");
        // Keep the default route prefix
        // setupAction.RoutePrefix = "";

        // Disable auto-refresh behavior
        setupAction.ConfigObject.AdditionalItems["persistAuthorization"] = true;
        setupAction.ConfigObject.AdditionalItems["tryItOutEnabled"] = true;
        setupAction.ConfigObject.AdditionalItems["displayRequestDuration"] = true;
        setupAction.ConfigObject.AdditionalItems["filter"] = "";
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
