using Prism;
using Prism.Ioc;
using Kanban.ViewModels;
using Kanban.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Kanban.Helpers;
using Kanban.Services.Settings;
using Kanban.Services.Api;
using Kanban.Services.Dialogs;
using Kanban.Services.LocalDatabase;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Kanban
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(NavigationConstants.Loader);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MasterPage, MasterPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<LoaderPage, LoaderPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            containerRegistry.RegisterForNavigation<ActivityPage, ActivityPageViewModel>();

            containerRegistry.RegisterSingleton<ApplicationContext>();
            containerRegistry.RegisterSingleton<ISettingsService, SettingsService>();
            containerRegistry.RegisterSingleton<IApiService, ApiService>();
            containerRegistry.RegisterSingleton<ILocalDatabaseService, LocalDatabaseService>();
            containerRegistry.RegisterSingleton<IDialogsService, DialogsService>();
            containerRegistry.RegisterForNavigation<LoaderPage, LoaderPageViewModel>();
        }
    }
}
