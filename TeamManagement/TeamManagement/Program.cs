using Data.Context;
using Data.Repository;
using Domain.Commands;
using Domain.DTOs;
using Domain.Handlers;
using Domain.Interfaces;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin",
    options =>
    options.AllowAnyOrigin()
    .AllowAnyMethod()
        .AllowAnyHeader()
    );
});
#region Transient
builder.Services.AddTransient<IRepository<Team>, Repository<Team>>();
builder.Services.AddTransient<IRequestHandler<PostCommand<Team>, string>, PostHandler<Team>>();
builder.Services.AddTransient<IRequestHandler<PostCommandSpecifique<Team>, Team>, PostHandlerSpecifique<Team>>();
builder.Services.AddTransient<IRequestHandler<PutCommandSpecifique<Team>, Team>, PutHandlerSpecifique<Team>>();
builder.Services.AddTransient<IRequestHandler<DeleteCommand<Team>, string>, DeleteHandler<Team>>();
builder.Services.AddTransient<IRequestHandler<GetListQuery<Team>, IEnumerable<Team>>, GetListHandler<Team>>();
builder.Services.AddTransient<IRequestHandler<GetQuery<Team>, Team>, GetHandler<Team>>();
builder.Services.AddTransient<IRepository<TeamUser>, Repository<TeamUser>>();
builder.Services.AddTransient<IRequestHandler<PostCommandSpecifique<TeamUser>, TeamUser>, PostHandlerSpecifique<TeamUser>>();
builder.Services.AddTransient<IRequestHandler<PostCommand<TeamUser>, string>, PostHandler<TeamUser>>();
builder.Services.AddTransient<IRequestHandler<PutCommandSpecifique<TeamUser>, TeamUser>, PutHandlerSpecifique<TeamUser>>();
builder.Services.AddTransient<IRequestHandler<DeleteEntitieCommand<TeamUser>, string>, DeleteEntityHandler<TeamUser>>();
builder.Services.AddTransient<IRequestHandler<GetListQuery<TeamUser>, IEnumerable<TeamUser>>, GetListHandler<TeamUser>>();
builder.Services.AddTransient<IRequestHandler<GetQuery<TeamUser>, TeamUser>, GetHandler<TeamUser>>();


#endregion
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(GetListHandler<Task>).Assembly);
});
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
