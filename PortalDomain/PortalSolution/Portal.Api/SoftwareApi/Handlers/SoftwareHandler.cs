using Marten;

using Portal.Api.SoftwareApi.Comands;
using Portal.Api.SoftwareApi.Entities;
using Portal.Api.SoftwareApi.Events;

using Wolverine.Attributes;

namespace Portal.Api.SoftwareApi.Handlers;

public static class SoftwareHandler
{

    public static async Task<SoftwareEntity> Handle(CreateSoftware command, IDocumentSession session, CancellationToken token)
    {
        var software = new SoftwareEntity(Guid.NewGuid(), command.Title, command.SourceId);
        session.Store(software);
        await session.SaveChangesAsync();
        return software;
    }

    public static async Task<IReadOnlyList<SoftwareEntity>> HandleAsync(GetSoftware _, IDocumentSession session)
    {
        var software = await GetActiveSoftware(session).ToListAsync();
        return software;
    }

    public static async Task<SoftwareEntity?> HandleAsync(GetSoftwareById command, IDocumentSession session)
    {
        var software = await GetActiveSoftware(session).SingleOrDefaultAsync(s => s.Id == command.Id);
        return software;
    }

    private static IQueryable<SoftwareEntity> GetActiveSoftware(IDocumentSession session)
    {
       return session.Query<SoftwareEntity>().Where(s => s.Retired == false);
    }

}