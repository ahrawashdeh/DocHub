namespace DocumentPlatform.Api.Services;

public class ScopedLifetimeService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
}
