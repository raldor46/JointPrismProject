using JointPrismProject.Objects;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JointPrismProject.ViewModels
{
    public class ViewClientPageViewModel : ViewModelBase
    {
        #region Properties
        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { SetProperty(ref _client, value); }
        }
        #endregion
        #region Commands
        #region Edit
        public DelegateCommand<object> cmdEdit { get; private set; }
        async void EditClient(object parameter)
        {
            var navigationParams = new NavigationParameters();
            var client = parameter as Client;
            navigationParams.Add("Client", client);
            await NavigationService.NavigateAsync("ViewClientPage", navigationParams);
        }
        #endregion
        #endregion
        public ViewClientPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Edit Client";
            #region Delegate Commands
            cmdEdit = new DelegateCommand<object>(EditClient);
            #endregion
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("Client", out Client client))
            {
                Client = client;
            }
            else
            {
                Client = new Client();
            }
        }
    }
}
