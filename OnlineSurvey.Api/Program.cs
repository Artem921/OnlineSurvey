using Framework.Utils;
using OnlineSurvey.Api.Mapping;
using OnlineSurvey.Application;
using OnlineSurvey.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
              .ConfigureApplicationPartManager(manager => manager.FeatureProviders.Add(new InternalControllerFeatureProvider()));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{

    options.Cookie.Name = "OnlineSuveySession";
    options.IdleTimeout = TimeSpan.FromDays(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureMapping();
builder.Services.RegisterModule<InfrastructureExtension>(builder.Configuration);
builder.Services.RegisterModule<ApplicationExtension>(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseSession();
app.UseAuthorization();
app.MapControllers();
app.Run();
