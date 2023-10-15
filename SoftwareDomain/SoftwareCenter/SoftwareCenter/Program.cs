using Consul;

using Microsoft.EntityFrameworkCore;

using SoftwareCenter.Data;
using SoftwareCenter.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var softwareConnectionString = builder.Configuration.GetConnectionString("software") ?? throw new Exception("No Connection String for Database");
builder.Services.AddDbContext<SoftwareDataContext>(options =>
{
    options.UseSqlite("Data Source=SoftwareCatalog.db");
});


var kafkaConnectionString = builder.Configuration.GetConnectionString("kafka") ?? throw new Exception("No Kafka Connection String");

builder.Services.AddCap(options =>
{
    options.UseKafka(kafkaConnectionString);
    options.UseInMemoryStorage(); // for outbox - should be durable, classroom code.
    options.UseDashboard(); // for classroom
});

builder.Services.AddScoped<SoftwareCatalogService>();
builder.Services.AddScoped<IPublishSoftwareMessages, CapKafkaPublishingService>();
// Configure the HTTP request pipeline.
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
