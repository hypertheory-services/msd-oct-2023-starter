using System.Text.Json;

using DotNetCore.CAP;

using Microsoft.AspNetCore.Http.Json;

using SoftwareCenter.Data;
using SoftwareCenter.Models;

namespace SoftwareCenter.Services;

public class CapKafkaPublishingService : IPublishSoftwareMessages
{
    private readonly ICapPublisher _publisher;

    public CapKafkaPublishingService(ICapPublisher publisher)
    {
        _publisher = publisher;
    }


    public async Task PublishNewTitleAsync(SoftwareInventoryItemEntity item)
    {
        await Publish<SoftwareItemCreated, SoftwareInventoryItemEntity>(item);
    }


    public async Task RetireSoftwareTitleAsync(SoftwareInventoryItemEntity item)
    {
        await Publish<SoftwareItemRetired, SoftwareInventoryItemEntity>(item);
    }

    private async Task Publish<TMessage, TEntity>(TEntity message)where TMessage : IPublishableEvent<TEntity, TMessage>
    {
        var messageToPublish = TMessage.From(message);
        
        await _publisher.PublishAsync<TMessage>(TMessage.TOPIC, messageToPublish);
 
    }


}
