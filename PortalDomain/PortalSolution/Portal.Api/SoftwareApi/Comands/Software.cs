using FluentValidation;

namespace Portal.Api.SoftwareApi.Comands;

public record CreateSoftware(string Title, string SourceId);

public record GetSoftware();
public record GetSoftwareById(Guid Id);

public record RetireSoftware(Guid Id);

public class CreateSoftwareValidator : AbstractValidator<CreateSoftware>
{
    public CreateSoftwareValidator()
    {
        RuleFor(s => s.Title).NotNull().NotEmpty().MinimumLength(5).MaximumLength(255);
    }
}