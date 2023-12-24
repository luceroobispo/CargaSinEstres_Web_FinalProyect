using CargaSinEstres.API.CargaSinEstres.Domain.Repositories;
using CargaSinEstres.API.CargaSinEstres.Domain.Services;
using CargaSinEstres.API.CargaSinEstres.Mapping;
using CargaSinEstres.API.CargaSinEstres.Persistence.Repositories;
using CargaSinEstres.API.CargaSinEstres.Services;
using CargaSinEstres.API.Security.Authorization.Handlers.Implementations;
using CargaSinEstres.API.Security.Authorization.Handlers.Interfaces;
using CargaSinEstres.API.Security.Authorization.Middleware;
using CargaSinEstres.API.Security.Authorization.Settings;
using CargaSinEstres.API.Security.Domain.Repositories;
using CargaSinEstres.API.Security.Domain.Services;
using CargaSinEstres.API.Security.Persistence.Repositories;
using CargaSinEstres.API.Security.Services;
using CargaSinEstres.API.Shared.Persistence.Contexts;
using CargaSinEstres.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CompanyRepository = CargaSinEstres.API.Security.Persistence.Repositories.CompanyRepository;
using CompanyService = CargaSinEstres.API.Security.Services.CompanyService;
using ErrorHandlerMiddleware = CargaSinEstres.API.Security.Authorization.Middleware.ErrorHandlerMiddleware;
using ICompanyRepository = CargaSinEstres.API.Security.Domain.Repositories.ICompanyRepository;
using ICompanyService = CargaSinEstres.API.Security.Domain.Services.ICompanyService;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{ 
    // Add API Documentation Information
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CARGA SIN ESTRÉS",
        Description = "CARGA SIN ESTRÉS RESTful API",
        Contact = new OpenApiContact
        {
            Name = "CSE.studio",
        },
        License = new OpenApiLicense
        {
            Name = "CSE Carga Sin Estrés Resources License",
        }
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
            },
            Array.Empty<string>()
        }
    });
});

//add database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

//add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Dependency Injection Configuration
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IBookingHistoryRepository, BookingHistoryRepository>();
builder.Services.AddScoped<IBookingHistoryService, BookingHistoryService>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipService, MembershipService>();

// Security Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IJwtHandler, JwtHandlerClient>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
// AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile),
    typeof(CargaSinEstres.API.Security.Mapping.ModelToResourceProfile),
    typeof(CargaSinEstres.API.Security.Mapping.ResourceToModelProfile)
    );

var app = builder.Build();

//validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

// Configure CORS 
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure Error Handler Middleware

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();