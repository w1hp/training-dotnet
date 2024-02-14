using Cvl.Training.SmsEmailSender.Core;
using Cvl.Training.SmsEmailSender.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDomain();
var infrastructureDbContextConnectionString = builder.Configuration.GetConnectionString("SmsEmailDbContext");
builder.Services.AddInfrastructure(infrastructureDbContextConnectionString);
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
