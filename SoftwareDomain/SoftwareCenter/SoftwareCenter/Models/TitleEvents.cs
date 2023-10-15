using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using SoftwareCenter.Data;

namespace SoftwareCenter.Models;

public interface IPublishableEvent<TFrom,TTo>
{
    static abstract string TOPIC { get; }
    static abstract TTo From(TFrom entity);
    
}
public class SoftwareItemCreated : IPublishableEvent<SoftwareInventoryItemEntity, SoftwareItemCreated>
{
    public static string TOPIC => "company.com.software.added";

    [Required]
    public string Id { get; set; } = string.Empty;
    [Required, MinLength(5), MaxLength(200)]
    public string TitleName { get; set; } = string.Empty;
    [Required]
    public string Publisher { get; set; } = string.Empty;
    [Required]
    public string SupportTech { get; set; } = string.Empty;

    public static SoftwareItemCreated From(SoftwareInventoryItemEntity item)
    {
        return new SoftwareItemCreated
        {
            Id = item.Id.ToString(),
            TitleName = item.TitleName,
            Publisher = item.Publisher,
            SupportTech = item.SupportTech
        };
    }
}

public class SoftwareItemRetired : IPublishableEvent<SoftwareInventoryItemEntity, SoftwareItemRetired>
{
    public static string TOPIC => "company.com.software.retired";


    [Required]
    public string Id { get; set; } = string.Empty;

    public static SoftwareItemRetired From(SoftwareInventoryItemEntity entity)
    {
        return new SoftwareItemRetired
        {
            Id = entity.Id.ToString()
        };
    }
}