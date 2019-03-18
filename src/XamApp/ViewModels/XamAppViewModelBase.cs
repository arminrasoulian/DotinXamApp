using Acr.UserDialogs;
using Bit.ViewModel;
using System;
using System.Threading.Tasks;
using XamApp.Resources.Strings;

namespace XamApp.ViewModels
{
    public class XamAppViewModelBase : BitViewModelBase
    {
        public XamAppViewModelBase()
        {
            LogoutCommand = new BitDelegateCommand(LogoutAsync);
        }

        public IUserDialogs UserDialogs { get; set; }

        public BitDelegateCommand LogoutCommand { get; set; }

        private async Task LogoutAsync()
        {
            // Todo: logout progress
            //using (UserDialogs.Loading(Strings.PleaseWait, maskType: MaskType.Gradient))
            //{
            //    // Login implementation ...
            //    await Task.Delay(TimeSpan.FromSeconds(3));
            //}

            await NavigationService.NavigateAsync("/Nav/Login");
        }
    }
}
