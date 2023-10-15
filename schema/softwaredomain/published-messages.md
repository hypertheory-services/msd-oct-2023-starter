# The Software Domain Publishes The Following Messages


## `SoftwareItemCreated`

**Topic:** : `company.com.software.added`

```csharp
public class SoftwareItemCreated 
{
    [Required]
    public string Id { get; set; } = string.Empty;
    [Required, MinLength(5), MaxLength(200)]
    public string TitleName { get; set; } = string.Empty;
    [Required]
    public string Publisher { get; set; } = string.Empty;
    [Required]
    public string SupportTech { get; set; } = string.Empty;

}

```

## `SoftwareItemRetired`

**Topic:**: `company.com.software.retired`

```csharp
public class SoftwareItemRetired
{
  
    [Required]
    public string Id { get; set; } = string.Empty;
  
}
```