using Acr.UserDialogs;
using Bit.ViewModel;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamApp.Dto;
using XamApp.Resources;
using XamApp.Resources.Strings;

namespace XamApp.ViewModels
{
    public class CardsViewModel : BitViewModelBase
    {
        public CardsViewModel()
        {
            ShowActionsCommand = new BitDelegateCommand<CardDto>(ShowActions);
        }        

        public IList<CardDto> Cards { get; set; }
        public IUserDialogs UserDialogs { get; set; }

        public BitDelegateCommand<CardDto> ShowActionsCommand { get; set; }

        private async Task ShowActions(CardDto card)
        {

        }

        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);

            // Todo: Get all cards
            using (UserDialogs.Loading(Strings.RetrievingData, maskType: MaskType.Gradient))
            {
                // Retrieving Data ...
                await Task.Delay(TimeSpan.FromSeconds(3));
                Cards = new List<CardDto>()
                {
                    new CardDto
                    {
                        CardNumber = "6621   0612   0567   2547",
                        CVV2= 443,
                        ExpireMonth = 10,
                        ExpireYear = 1399,
                        Title = "آرمین رسولیان"
                    },
                    new CardDto
                    {
                        CardNumber = "6104   3375   2156   5034",
                        CVV2= 392,
                        ExpireMonth = 07,
                        ExpireYear = 1402,
                        Title = "علی حکمی"
                    }
                };
            }
        }
    }
}
