using SoftwareCenter.Models;

namespace SoftwareCenter.Data;

public class SoftwareInventoryItemEntity
{
    public int Id { get; set; }
    public string TitleName { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string SupportTech { get; set; } = string.Empty;
    public bool Retired { get; set; } = false;

    public static SoftwareInventoryItemEntity From(TitleCreateModel model)
    {
        return new SoftwareInventoryItemEntity
        {
            TitleName = model.TitleName,
            Publisher = model.Publisher,
            Retired = false,
            SupportTech = model.SupportTech
        };
    }
}