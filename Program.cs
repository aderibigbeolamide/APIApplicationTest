using APIApplication.Implementations.Repositories;
using APIApplication.Implementations.Services;
using APIApplication.Interfaces.Repositories;
using APIApplication.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IAppProgramService, AppProgramService>();
builder.Services.AddScoped<IPreviewService, PreviewService>();
builder.Services.AddScoped<IWorkflowService, WorkflowService>();
var app = builder.Build();

// Add Repository to the container.
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IAppProgramRepository, AppProgramRepository>();
builder.Services.AddScoped<IPreviewRepository, PreviewRepository>();
builder.Services.AddScoped<IWorkflowRepository, WorkflowRepository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();

app.Run();
