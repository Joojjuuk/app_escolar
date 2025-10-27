using AppEscolar_BackEnd.Data;
using AppEscolar_BackEnd.Services.Token;
using AppEscolar_BackEnd.Services.Aluno;
using AppEscolar_BackEnd.Services.Interfaces;
using AppEscolar_BackEnd.Services.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AppEscolar_BackEnd.Services.Adm;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdmService, AdmService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppEscolar_BackEnd.Configuration.PrivateKey))
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();