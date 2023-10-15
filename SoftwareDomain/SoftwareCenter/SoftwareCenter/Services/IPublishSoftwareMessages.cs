using SoftwareCenter.Data;

namespace SoftwareCenter.Services;
public interface IPublishSoftwareMessages
{
    Task PublishNewTitleAsync(SoftwareInventoryItemEntity item);
    Task RetireSoftwareTitleAsync(SoftwareInventoryItemEntity item);
}