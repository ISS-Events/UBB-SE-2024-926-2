using System.Windows;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeBuddies
{
    public partial class App : Application
    {
        private readonly IHost host;
        static private void Register(HostBuilderContext discard, IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IBuddyService, BuddyService>();
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddSingleton<IQuestionFeedService, QuestionFeedService>();
            services.AddSingleton<ISessionService, SessionService>();
            // Repos
        }
        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices(Register)
                .Build();
        }

        private async void InitialiseServicesAndShowMainPage(object sender, StartupEventArgs e)
        {
            await host.StartAsync();
            MainWindow mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs args)
        {
            await host.StopAsync();
            host.Dispose();
            base.OnExit(args);
        }
    }
}
