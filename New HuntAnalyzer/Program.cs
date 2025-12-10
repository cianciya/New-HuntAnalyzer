using System.Text;
using Dominio.Mapper;
using Dominio.Token;
using Infraestrutura.Contexto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Banco de dados
builder.Services.AddDbContext<ClienteContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlOption =>
    {
        sqlOption.CommandTimeout(180);
    })
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()))
    .EnableSensitiveDataLogging(), ServiceLifetime.Scoped);

// 🌐 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .WithExposedHeaders("Content-Disposition");
    });
});

// 🔁 AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton(provider => AutoMapperConfig.RegisterMaps().CreateMapper());


// 🔐 Autenticação JWT
var key = Encoding.ASCII.GetBytes(TokenSettings.Secret);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(c =>
{
    c.RequireHttpsMetadata = false;
    c.SaveToken = true;
    c.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true, 
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero 
    };
});

// 📄 Swagger + JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Tibia Tracker",
        Description = "API para registrar sessões do Tibia e consultar histórico"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autorização via JWT. Ex: 'Bearer {seu_token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

// 👮 Autorização
builder.Services.AddAuthorization();

// 🚀 Controllers
builder.Services.AddControllers();

var app = builder.Build();

// 🌍 Pipeline

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"{(app.Environment.IsDevelopment() ? string.Empty : "..")}/swagger/v1/swagger.json", "API Tibia Tracker");
    c.RoutePrefix = "swagger"; // deixa a UI em /swagger
});


//app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

// 🔑 Autenticação/Autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "API Online 🚀");
app.MapControllers();

app.Run();
