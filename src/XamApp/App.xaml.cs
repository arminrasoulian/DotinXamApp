﻿using Acr.UserDialogs;
using Autofac;
using Bit;
using Bit.ViewModel.Contracts;
using Bit.ViewModel.Implementations;
using FormsControls.Base;
using Microsoft.Extensions.DependencyInjection;
using Prism;
using Prism.Ioc;
using System.Globalization;
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
        public static new App Current
        {
            get { return (App)Xamarin.Forms.Application.Current; }
        }

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

            // await NavigationService.NavigateAsync("/Nav/HelloWorld"); // Simple tap counter sample

            // await NavigationService.NavigateAsync("/MasterDetail/Nav/HelloWorld"); // Simple tap counter sample in master detail
            // await NavigationService.NavigateAsync("/Nav/HelloWorld/Intro"); // Popup page
             await NavigationService.NavigateAsync("/Nav/Login"); // Simple login form sample
            // await NavigationService.NavigateAsync("/Nav/Products"); // List view sample
            // await NavigationService.NavigateAsync("/Nav/PlatformSpecificSamples"); // Platform specific sample
            // await NavigationService.NavigateAsync("/Nav/Animations"); // Animations
            // await NavigationService.NavigateAsync("/Nav/RestSamples"); // rest api call sample

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
                AppName = "XamApp",
            }).SingleInstance();

            containerBuilder.RegisterRequiredServices();
            containerBuilder.RegisterHttpClient();
            containerBuilder.RegisterIdentityClient();

            containerBuilder.RegisterInstance(UserDialogs.Instance);

            base.RegisterTypes(containerRegistry, containerBuilder, services);
        }
    }
}
