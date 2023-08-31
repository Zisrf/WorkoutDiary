using Zisrf.WorkoutDiary.Web.Configurations;
using Zisrf.WorkoutDiary.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = Configuration.Parse(builder.Configuration);

builder.Services.Configure(configuration);

var application = builder.Build();

application.Configure();

await application.InitializeAsync();

await application.RunAsync();