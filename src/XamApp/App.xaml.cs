using Acr.UserDialogs;
using Autofac;
using Bit;
using Bit.ViewModel.Contracts;
using Bit.ViewModel.Implementations;
using FFImageLoading;
using Microsoft.Extensions.DependencyInjection;
using Prism;
using Prism.Ioc;
using Refit;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using XamApp.Resources.Strings;
using XamApp.ViewModels;
using XamApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamApp
{
    public partial class App : BitApplication
    {
        public static new App Current => (App)Xamarin.Forms.Application.Current;

        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
#if DEBUG
            LiveReload.Init();
#endif
        }

        protected override async Task OnInitializedAsync()
        {
            InitializeComponent();

            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

            Strings.Culture = CultureInfo.CurrentUICulture = new CultureInfo("fa");

            bool isLoggedIn = await Container.Resolve<ISecurityService>().IsLoggedInAsync();

            if (isLoggedIn)
            {
                await NavigationService.NavigateAsync("/Master/Nav/ToDoItems");
            }
            else
            {
                await NavigationService.NavigateAsync("/Nav/Login");
            }

            await base.OnInitializedAsync();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry, ContainerBuilder containerBuilder, IServiceCollection services)
        {
            containerRegistry.RegisterForNav<NavigationPage>("Nav");
            containerRegistry.RegisterForNav<XamAppMasterDetailView, XamAppMasterDetailViewModel>("MasterDetail");
            containerRegistry.RegisterForNav<HelloWorldView, HelloWorldViewModel>("HelloWorld");
            containerRegistry.RegisterForNav<HelloWorldMultiLanguageView, HelloWorldViewModel>("HelloWorldMultiLanguage");
            containerRegistry.RegisterForNav<LoginView, LoginViewModel>("Login");
            containerRegistry.RegisterForNav<IntroView, IntroViewModel>("Intro");
            containerRegistry.RegisterForNav<ProductsView, ProductsViewModel>("Products");
            containerRegistry.RegisterForNav<PlatformSpecificSamplesView, PlatformSpecificSamplesViewModel>("PlatformSpecificSamples");
            containerRegistry.RegisterForNav<AnimationsView, AnimationsViewModel>("Animations");
            containerRegistry.RegisterForNav<RestSamplesView, RestSamplesViewModel>("RestSamples");
            containerRegistry.RegisterForNav<OTPCodeView, OTPCodeViewModel>("OTP");
            containerRegistry.RegisterForNav<CardsView, CardsViewModel>("Cards");

            containerBuilder.Register<IClientAppProfile>(c => new DefaultClientAppProfile
            {
                HostUri = new Uri("https://example.ir"),
                TokenEndpoint = "",
                AppName = "XamApp"
            }).SingleInstance();

            containerBuilder.RegisterRequiredServices();
            containerBuilder.RegisterHttpClient();
            containerBuilder.RegisterIdentityClient();

            containerBuilder.RegisterInstance(UserDialogs.Instance);

            //Register custom HttpClient for FFImageLoading to receive token
            //ImageService.Instance.Initialize(new FFImageLoading.Config.Configuration
            //{
            //    HttpClient = Container.Resolve<HttpClient>()
            //});

            containerBuilder.Register(c => RestService.For<INetworkService>(c.Resolve<HttpClient>()));


            base.RegisterTypes(containerRegistry, containerBuilder, services);
        }
    }
}
