# Code Snippets We Might Need

## Getting the User Id

```csharp
    private static  string GuardGetUserIdentity(IHttpContextAccessor context)
    {
        return context.HttpContext?.User?.Claims?
                   .SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value
               ?? throw new Exception("Must be authenticated");
    }
```