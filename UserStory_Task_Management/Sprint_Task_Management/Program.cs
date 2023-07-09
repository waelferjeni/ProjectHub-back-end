using Data.Context;
using Data.Repository;
using Domain.Commands;
using Domain.Handlers;
using Domain.Interface;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.Extensions.Options;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Net.Sockets;
using Task = Domain.Models.Task;
using Domain.DTOs;

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
builder.Services.AddTransient<IRepository<Task>, Repository<Task>>();
builder.Services.AddTransient<IRequestHandler<PostCommandSpecifique<Task>, Task>, PostHandlerSpecifique<Task>>();
builder.Services.AddTransient<IRequestHandler<PostCommand<Task>, string>, PostHandler<Task>>();
builder.Services.AddTransient<IRequestHandler<PutCommandSpecifique<Task>, Task>, PutHandlerSpecifique<Task>>();
builder.Services.AddTransient<IRequestHandler<DeleteCommand<Task>, string>, DeleteHandler<Task>>();
builder.Services.AddTransient<IRequestHandler<GetListQuery<Task>, IEnumerable<Task>>, GetListHandler<Task>>();
builder.Services.AddTransient<IRequestHandler<GetQuery<Task>, Task>, GetHandler<Task>>();
builder.Services.AddTransient<IRepository<UserStory>, Repository<UserStory>>();
builder.Services.AddTransient<IRequestHandler<PostCommandSpecifique<UserStory>, UserStory>, PostHandlerSpecifique<UserStory>>();
builder.Services.AddTransient<IRequestHandler<PostCommand<UserStory>, string>, PostHandler<UserStory>>();
builder.Services.AddTransient<IRequestHandler<PutCommand<UserStory>, string>, PutHandler<UserStory>>();
builder.Services.AddTransient<IRequestHandler<PutCommandSpecifique<UserStory>, UserStory>, PutHandlerSpecifique<UserStory>>();
builder.Services.AddTransient<IRequestHandler<DeleteCommand<UserStory>, string>, DeleteHandler<UserStory>>();
builder.Services.AddTransient<IRequestHandler<GetListQuery<UserStory>, IEnumerable<UserStory>>, GetListHandler<UserStory>>();
builder.Services.AddTransient<IRequestHandler<GetQuery<UserStory>, UserStory>, GetHandler<UserStory>>();
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
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
