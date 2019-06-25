using System.Threading.Tasks;
using System.Windows.Input;
using ComicVibe.App.Helpers;
using ComicVibe.App.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace ComicVibe.App.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : ViewModelBase
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public ElementTheme ElementTheme
        {
            get => _elementTheme;
            set => Set(ref _elementTheme, value);
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get => _versionDescription;
            set => Set(ref _versionDescription, value);
        }

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                return _switchThemeCommand ?? (_switchThemeCommand = new RelayCommand<ElementTheme>(
                           async (param) =>
                           {
                               ElementTheme = param;
                               await ThemeSelectorService.SetThemeAsync(param);
                           }));
            }
        }

        public async Task InitializeAsync()
        {
            VersionDescription = GetVersionDescription();
            await Task.CompletedTask;
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
