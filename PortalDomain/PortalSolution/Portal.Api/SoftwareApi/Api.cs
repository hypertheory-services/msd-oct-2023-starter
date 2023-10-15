using Microsoft.AspNetCore.Http.HttpResults;

using Portal.Api.SoftwareApi.Comands;
using Portal.Api.SoftwareApi.Entities;
using Portal.Api.SoftwareApi.Events;

using Wolverine;

namespace Portal.Api.SoftwareApi;

public static class Api
{
    public static RouteGroupBuilder MapSoftwareCatalogApi(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/software");


        group.WithTags("Software");
        group.RequireCors("cors");

        group.MapPost("/", async Task<CreatedAtRoute<SoftwareEntity>> (CreateSoftware command, IMessageBus bus) =>
        {
            var response = await bus.InvokeAsync<SoftwareEntity>(command);
           
            return TypedResults.CreatedAtRoute(routeName: "Get-Software-By-Id", routeValues: new { id = response.Id }, value: response);
        });

        group.MapGet("/", async Task<Ok<IReadOnlyList<SoftwareEntity>>> (IMessageBus bus) =>
        {
            var software = await bus.InvokeAsync<IReadOnlyList<SoftwareEntity>>(new GetSoftware());
            return TypedResults.Ok(software);
        });

        group.MapGet("/{id:guid}", async Task<Results<Ok<SoftwareEntity>, NotFound>> (Guid id, IMessageBus bus) =>
        {
            var software = await bus.InvokeAsync<SoftwareEntity?>(new GetSoftwareById(id));
            return software switch
            {
                null => TypedResults.NotFound(),
                _ => TypedResults.Ok(software)
            };
        }).WithName("Get-Software-By-Id");

        group.MapHub<SoftwareHub>("/hub");
        return group;
    }
}