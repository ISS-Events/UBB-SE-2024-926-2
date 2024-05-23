using System.Windows;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
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
            services.AddSingleton<IBuddyRepository, BuddyRepository>();
            services.AddSingleton<INotificationRepository, NotificationRepository>();
            services.AddSingleton<ISessionRepository, SessionRepository>();
            services.AddSingleton<IQuestionFeedRepository, QuestionFeedRepository>();
        }
        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices(Register)
                .Build();
            ServiceLocator.ServiceProvider = host.Services;
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
