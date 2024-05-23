using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Services
{
    public static class ServiceLocator
    {
        public static IServiceProvider ServiceProvider { get; set; }
    }
}
