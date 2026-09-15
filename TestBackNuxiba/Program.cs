using Microsoft.EntityFrameworkCore;
using TestBackNuxiba.Data;
using TestBackNuxiba.Handlers;
using TestBackNuxiba.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CCenterDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IReportService, ReportService>();

// Global error handling: every error is returned as ProblemDetails (application/problem+json)
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
