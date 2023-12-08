using Microsoft.EntityFrameworkCore;
using UserRepository.Data;
using UserRepository.Helper;
using UserRepository.Interfaces;
using UserRepository.Services;
using UserRepository.Repository;
using UserRepository.Middlewares;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserRepository, UserRepository.Repository.UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.Configure<HashSettings>(builder.Configuration.GetSection(HashSettings.SectionName));
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableDetailedErrors();

});




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

