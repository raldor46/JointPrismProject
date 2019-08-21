using Prism;
using Prism.Ioc;
using JointPrismProject.ViewModels;
using JointPrismProject.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JointPrismProject.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace JointPrismProject
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

            DatabaseService.Start();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<EditClientPage, EditClientPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewClientPage, ViewClientPageViewModel>();
        }
    }
}
