
using Portal.Api.Infra;
using Portal.Api.SoftwareApi;

var builder = WebApplication.CreateBuilder(args);

builder.AddPortalInfraServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapSoftwareCatalogApi();

app.Run();