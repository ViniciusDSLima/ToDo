using API.Request;
using API.Request.Assignment;
using API.Request.AssignmentList;
using AutoMapper;
using ClassLibrary3.DTO;
using ClassLibrary3.Models;
using ClassLibrary4.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScottBrady91.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var autoMapperConfig = new MapperConfiguration(config =>
{
    config.CreateMap<User, UserDTO>().ReverseMap();
    config.CreateMap<RegisterUsuarioRequest, UserDTO>().ReverseMap();
    config.CreateMap<UserDTO, UpdateUsuarioRequest>().ReverseMap();

    config.CreateMap<Assignment, AssignmentDTO>().ReverseMap();
    config.CreateMap<RegisterAssignmentRequest, UserDTO>().ReverseMap();
    config.CreateMap<UserDTO, UpdateAssignmentRequest>().ReverseMap();

    config.CreateMap<AssignmentList, AssignmentListDTO>().ReverseMap();
    config.CreateMap<RegisterAssignmentListRequest, AssignmentListDTO>().ReverseMap();
    config.CreateMap<AssignmentListDTO, UpdateAssignmentListRequest>().ReverseMap();


});


var mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher<User>, Argon2PasswordHasher<User>>();

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

app.Run();