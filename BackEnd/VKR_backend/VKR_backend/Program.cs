using Api.Interfaces.Repositories;
using Api.Interfaces.Services;
using Api.Services;
using DataBase;
using DataBase.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using VKR_backend.Extantions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VKRDBContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(VKRDBContext)));
    });

var configuration = builder.Configuration;
var jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();


builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();


//Repositories
builder.Services.AddScoped<IAgrigatesRepository, AgrigatesRepository>();
builder.Services.AddScoped<ICertificatesRepository, CertificatesRepository>();
builder.Services.AddScoped<IContractsRepository, ContractsRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IResumesRepository, ResumesRepository>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Services
builder.Services.AddScoped<IAgrigatesService, AgrigatesService>();
builder.Services.AddScoped<ICertificatesService, CertificatesService>();
builder.Services.AddScoped<IContractsService, ContractsService>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IResumeService, ResumeService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IUserServices, UserServices>();



builder.Services.AddAPIAuthentication(jwtOptions);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
