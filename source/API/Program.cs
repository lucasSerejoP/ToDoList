using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using API.Application.Commands;
using API.Application.Queries;
using INFRA.Data;
using Microsoft.EntityFrameworkCore;
using DOMAIN.Aggregates.TaskAggregates;
using INFRA.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllers();

// Adicionar o DbContext
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar o MediatR
builder.Services.AddMediatR(typeof(CreateTaskCommand).Assembly);

// Adicionar o repositório
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Adicionar o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoList API", Version = "v1" });
});

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList API V1");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();