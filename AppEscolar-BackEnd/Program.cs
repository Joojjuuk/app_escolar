using AppEscolar_BackEnd.Data;
using AppEscolar_BackEnd.Services.Token;
using AppEscolar_BackEnd.Services.Aluno;
using AppEscolar_BackEnd.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AppEscolar_BackEnd.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.MapGet("/", (TokenService service
    ) => service.Generate(new UsuarioModel
    {
        Id = Guid.NewGuid(),
        Email = "Teste@email.com",
        Senha = "123",
        TipoUsuario = ETipoUsuario.Aluno,


    }));

app.Run();
