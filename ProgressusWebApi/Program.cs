using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProgressusWebApi.Data;
using ProgressusWebApi.Repositories;
using ProgressusWebApi.Repositories.Interfaces;
using ProgressusWebApi.Services;
using ProgressusWebApi.Services.Interfaces;
using SendGrid.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    

//agrega automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// inyección de repositories
builder.Services.AddScoped<IGrupoMuscularRepository, GrupoMuscularRepository>();
builder.Services.AddScoped<IMusculoRepository, MusculoRepository>();
builder.Services.AddScoped<IEjercicioRepository, EjercicioRepository>();
builder.Services.AddScoped<MusculoDeEjercicioRepository, MusculoDeEjercicioRepository>();

// inyección de services
builder.Services.AddScoped<IGrupoMuscularService, GrupoMuscularService>();
builder.Services.AddScoped<IMusculoService, MusculoService>();
builder.Services.AddScoped<IEjercicioService, EjercicioService>();
builder.Services.AddScoped<IMusculoDeEjercicioService, MusculoDeEjercicioService>();

//???
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


//Email Sender
builder.Services.AddSendGrid(options =>
    options.ApiKey = builder.Configuration["SendGridKey"]!
);
builder.Services.AddTransient<IEmailSender, EmailSender>();


builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
