using SubmissionProcessor.Worker.Consumer;
using Microsoft.EntityFrameworkCore;
using Shared.Data;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<SubmissionConsumer>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
 
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var host = builder.Build();
host.Run();
