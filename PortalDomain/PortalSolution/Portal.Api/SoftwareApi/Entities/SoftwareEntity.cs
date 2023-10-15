namespace Portal.Api.SoftwareApi.Entities;

public record SoftwareEntity(Guid Id, string Title, string SourceId, bool Retired = false);