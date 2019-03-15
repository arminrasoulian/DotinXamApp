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
        public IList<CardDto> Cards { get; set; }
        public IUserDialogs UserDialogs { get; set; }


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
                        CardNumber = "6621 0612 0567 2547",
                        CVV2= 392,
                        ExpireMonth = 10,
                        ExpireYear = 1399,
                        Title = "داتین"
                    },
                    new CardDto
                    {
                        CardNumber = "6621 0612 0567 2547",
                        CVV2= 392,
                        ExpireMonth = 10,
                        ExpireYear = 1399,
                        Title = ""
                    }
                };
            }
        }
    }
}
