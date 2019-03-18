using Acr.UserDialogs;
using Bit.ViewModel;
using Prism.Services;
using System;
using System.Threading.Tasks;
using XamApp.Resources;
using XamApp.Resources.Strings;

namespace XamApp.ViewModels
{
    public class OTPCodeViewModel : XamAppViewModelBase
    {
        public OTPCodeViewModel()
        {
            VerifyOTPCommand = new BitDelegateCommand(VerifyOTP);
        }

        public string OTPCode { get; set; }

        public BitDelegateCommand VerifyOTPCommand { get; set; }

        public IUserDialogs UserDialogs { get; set; }
        public IPageDialogService PageDialogService { get; set; }


        private async Task VerifyOTP()
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
            
            await NavigationService.NavigateAsync("/Nav/Cards");
        }

        private async Task<bool> ValidateInputsAsync()
        {
            if (string.IsNullOrEmpty(OTPCode))
            {
                await PageDialogService.DisplayAlertAsync(Strings.OTPCodeIsRequired, Strings.PleaseEnterOTPCode, Strings.OK);
                return false;
            }

            return true;
        }

    }
}
