using Acr.UserDialogs;
using Bit.ViewModel;
using Prism.Services;
using System;
using System.Threading.Tasks;
using XamApp.Resources;
using XamApp.Resources.Strings;

namespace XamApp.ViewModels
{
    public class LoginViewModel : XamAppViewModelBase
    {
        public string PhoneNumber { get; set; }

        public BitDelegateCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new BitDelegateCommand(Login);
        }

        public IUserDialogs UserDialogs { get; set; }
        public IPageDialogService PageDialogService { get; set; }

        public async Task Login()
        {
            // Validation
            var isFormValid = await ValidateInputsAsync();
            if (!isFormValid)
                return;

            using (UserDialogs.Loading(Strings.PleaseWait, maskType: MaskType.Gradient))
            {
                // Login implementation ...
                await Task.Delay(TimeSpan.FromSeconds(3));
            }

            //await NavigationService.NavigateAsync("/Intro");
            //await NavigationService.NavigateAsync("/Nav/HelloWorld");
            //await NavigationService.NavigateAsync("/MasterDetail/Nav/HelloWorld");
            await NavigationService.NavigateAsync("OTP");
        }

        private async Task<bool> ValidateInputsAsync()
        {
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                await PageDialogService.DisplayAlertAsync(Strings.PhoneNumberIsRequired, Strings.PleaseEnterPhoneNumber, Strings.OK);
                return false;
            }

            return true;
        }
    }
}
