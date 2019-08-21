using JointPrismProject.Objects;
using JointPrismProject.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace JointPrismProject.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Properties
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { SetProperty(ref _clients, value); }
        }
        #endregion
        #region Commands
        #region AddClient
        public DelegateCommand<object> cmdAddClient { get; private set; }
        async void AddClient(object parameter)
        {
            await NavigationService.NavigateAsync("EditClientPage");
        }
        #endregion
        #region ViewClient
        public DelegateCommand<object> cmdViewClient { get; private set; }
        async void ViewClient(object parameter)
        {
            var navigationParams = new NavigationParameters();
            var client = parameter as Client;
            navigationParams.Add("Client", client);
            await NavigationService.NavigateAsync("ViewClientPage", navigationParams);
        }
        #endregion
        #endregion
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            #region Delegate Commands
            cmdAddClient = new DelegateCommand<object>(AddClient);
            cmdViewClient = new DelegateCommand<object>(ViewClient);
            #endregion
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            var clients = await DatabaseService.ClientDatabase.GetClientsAsync();
            Clients = new ObservableCollection<Client>(clients);
        }
    }
}
