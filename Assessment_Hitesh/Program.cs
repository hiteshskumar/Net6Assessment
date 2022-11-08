
using Assessment_Hitesh.Data;
using Microsoft.EntityFrameworkCore;

using Assessment_Hitesh.Data.Entities;
using Assessment_Hitesh.Controllers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RawDataDBContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("AssessmentDatabase"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
