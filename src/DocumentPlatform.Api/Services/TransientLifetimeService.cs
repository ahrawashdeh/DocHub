namespace DocumentPlatform.Api.Services;

public class TransientLifetimeService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
}
