using System;
using System.Threading.Tasks;
using ComicVibe.App.Helpers;
using ComicVibe.App.Services;
using ComicVibe.App.Views;
using GalaSoft.MvvmLight.Ioc;

namespace ComicVibe.App.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            _ = LoadConfiguration();

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        private static async Task<IConfiguration> LoadConfiguration()
        {
            IConfiguration configuration = new Configuration();
            await configuration.Init();
            SimpleIoc.Default.Register(() => configuration);

            return configuration;
        }

        public SettingsViewModel Settings => SimpleIoc.Default.GetInstance<SettingsViewModel>();

        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ShellViewModel Shell => SimpleIoc.Default.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => SimpleIoc.Default.GetInstance<NavigationServiceEx>();

        public void Register<TVm, TV>()
            where TVm : class
        {
            SimpleIoc.Default.Register<TVm>();

            NavigationService.Configure(typeof(TVm).FullName, typeof(TV));
        }
    }
}
