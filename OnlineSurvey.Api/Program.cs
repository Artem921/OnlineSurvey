using Framework.Utils;
using Microsoft.OpenApi.Models;
using OnlineSurvey.Application;
using OnlineSurvey.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddControllers()
              .ConfigureApplicationPartManager(manager => manager.FeatureProviders.Add(new InternalControllerFeatureProvider()))
              .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });;
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{

    options.Cookie.Name = "OnlineSuveySession";
    options.IdleTimeout = TimeSpan.FromDays(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Version ="v1",
        Title = "Online Survey",

    });

    var basePath = AppContext.BaseDirectory;
    var xmlPath = Path.Combine(basePath, "OnlineSurvey.xml");
    options.IncludeXmlComments(xmlPath);


});
builder.Services.RegisterModule<InfrastructureExtension>(builder.Configuration);
builder.Services.RegisterModule<ApplicationExtension>(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseSession();
app.UseAuthorization();
app.MapControllers();
app.Run();
