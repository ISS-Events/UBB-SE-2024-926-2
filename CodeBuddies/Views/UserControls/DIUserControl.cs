using System.Windows.Controls;
using CodeBuddies.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.Views.UserControls
{
    public class DIUserControl : UserControl
    {
        protected IServiceProvider ServiceProvider { get; }
        public DIUserControl()
        {
            ServiceProvider = ServiceLocator.ServiceProvider;
            ServiceProvider.GetRequiredService(typeof(DIUserControl));
        }

        protected Type GetService<Type>() => ServiceProvider.GetRequiredService<Type>();
    }
}
