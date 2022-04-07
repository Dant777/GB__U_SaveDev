using AbstractionLayer;
using BusinessLogicLayer;
using DataLayer;
using Domain.Core.Entities.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using DataLayer.Mongo;
using Elasticsearch.Net;
using FluentValidation.AspNetCore;
using GB__U_SaveDev.Consul;
using GB__U_SaveDev.Mapper;
using Nest;
using SignLibrary.Lesson_3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Services

builder.Services.AddControllers().AddFluentValidation(fv =>
{
    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;

});

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//bd
builder.Services.AddDbContext<AppDataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));

//Elastic
var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200/"));
var setting = new ConnectionSettings(pool)
    .DefaultIndex("books");
var client = new ElasticClient(setting);
builder.Services.AddSingleton(client);

//Consul
builder.Services.AddSingleton<IConsulRegisterService, ConsulRegisterService>();
builder.Services.Configure<MenuConfiguration>(builder.Configuration.GetSection("Menu"));
builder.Services.Configure<ConsulConfiguration>(builder.Configuration.GetSection("Consul"));
//JwtConfig Authentication 
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);

    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        RequireExpirationTime = false
    };
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDataContext>();

//DI Layer regist
builder.Services.RegisterAbstractLayer();
builder.Services.RegisterBusinessLogic();
builder.Services.RegisterAuthLogic();


#endregion


#region Pipeline

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();

#endregion

