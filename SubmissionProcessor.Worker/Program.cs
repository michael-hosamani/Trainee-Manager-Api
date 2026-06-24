using SubmissionProcessor.Worker.Consumer;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<SubmissionConsumer>();

var host = builder.Build();
host.Run();
