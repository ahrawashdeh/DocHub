namespace DocumentPlatform.Api.Services;

public class SingletonLifetimeService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
}
