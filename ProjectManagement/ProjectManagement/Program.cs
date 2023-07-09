using Data.Context;
using Data.Repository;
using Domain.Commands;
using Domain.Handlers;
using Domain.Interface;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin",
   options =>
    options.AllowAnyOrigin()
    .AllowAnyMethod()
        .AllowAnyHeader()
    );
});


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAnyOrigin",
//        builder => builder.AllowAnyOrigin()
//                          .AllowAnyMethod()
//                          .AllowAnyHeader());
//});
#region project transient
builder.Services.AddTransient<IRepository<Project>, Repository<Project>>();
builder.Services.AddTransient<IRequestHandler<PostCommand<Project>, string>, PostHandler<Project>>();
builder.Services.AddTransient<IRequestHandler<PostCommandSpecifique<Project>, Project>, PostHandlerSpecifique<Project>>();
builder.Services.AddTransient<IRequestHandler<PutCommand<Project>, string>, PutHandler<Project>>();
builder.Services.AddTransient<IRequestHandler<DeleteCommand<Project>, string>, DeleteHandler<Project>>();
builder.Services.AddTransient<IRequestHandler<GetListQuery<Project>, IEnumerable<Project>>, GetListHandler<Project>>();
builder.Services.AddTransient<IRequestHandler<GetQuery<Project>, Project>, GetHandler<Project>>();
#endregion

#region sprint transient
builder.Services.AddTransient<IRepository<Sprint>, Repository<Sprint>>();
builder.Services.AddTransient<IRequestHandler<PostCommandSpecifique<Sprint>, Sprint>, PostHandlerSpecifique<Sprint>>();
builder.Services.AddTransient<IRequestHandler<PostCommand<Sprint>, string>, PostHandler<Sprint>>();
builder.Services.AddTransient<IRequestHandler<PutCommandSpecifique<Sprint>, Sprint>, PutHandlerSpecifique<Sprint>>();
builder.Services.AddTransient<IRequestHandler<DeleteCommand<Sprint>, string>, DeleteHandler<Sprint>>();
builder.Services.AddTransient<IRequestHandler<GetListQuery<Sprint>, IEnumerable<Sprint>>, GetListHandler<Sprint>>();
builder.Services.AddTransient<IRequestHandler<GetQuery<Sprint>, Sprint>, GetHandler<Sprint>>();
#endregion

#region  service transient
builder.Services.AddTransient<IRepository<Service>, Repository<Service>>();
builder.Services.AddTransient<IRequestHandler<PostCommandSpecifique<Service>, Service>, PostHandlerSpecifique<Service>>();
builder.Services.AddTransient<IRequestHandler<PostCommand<Service>, string>, PostHandler<Service>>();
builder.Services.AddTransient<IRequestHandler<PutCommand<Service>, string>, PutHandler<Service>>();
builder.Services.AddTransient<IRequestHandler<DeleteCommand<Service>, string>, DeleteHandler<Service>>();
builder.Services.AddTransient<IRequestHandler<GetListQuery<Service>, IEnumerable<Service>>, GetListHandler<Service>>();
builder.Services.AddTransient<IRequestHandler<GetQuery<Service>, Service>, GetHandler<Service>>();
#endregion


builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(GetListHandler<Sprint>).Assembly);
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
