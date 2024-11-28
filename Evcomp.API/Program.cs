using Evcomp.API.Configurations;
using Evcomp.API.Data;
using Evcomp.API.Models;
using Evcomp.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IS3Service, S3Service>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<AwsSettings>(builder.Configuration.GetSection("AWS"));

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbConnection"));
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
