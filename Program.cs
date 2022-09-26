using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Filmes.Services.Interfaces;
using FilmesAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using Filmes.Infra;
using Filmes.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts
       .UseMySql(
            builder
                .Configuration
                // TODO: Mover para appsettings.json
                .GetConnectionString("FilmeConnection"),
                new MySqlServerVersion(new Version(8, 0))
            )
       .UseLazyLoadingProxies(),
       ServiceLifetime.Transient);

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(token =>
    {
        token.RequireHttpsMetadata = false;
        token.SaveToken = true;
        token.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                // TODO: Mover para appsettings.json
                Encoding.UTF8.GetBytes("0asdas09dasdasdas098asdasdasd687asdasd876asasd09a")),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("IdadeMinima", policy =>
    {
        policy.Requirements.Add(new IdadeMinimaRequirement(18));
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, IdadeMinimaHandler>();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IGerenteService, GerenteService>();
builder.Services.AddScoped<ISessaoService, SessaoService>();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
