using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors(options =>

{

    options.AddPolicy("CorsPolicy", policy =>

    {

        // Puedes restringir a los orígenes que necesites

        policy.WithOrigins("http://localhost:5047", "https://localhost:7145")

              .AllowAnyHeader()

              .AllowAnyMethod();

    });

});
 

builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();