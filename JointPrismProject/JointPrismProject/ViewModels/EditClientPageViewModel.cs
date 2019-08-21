using JointPrismProject.Objects;
using JointPrismProject.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JointPrismProject.ViewModels
{
    public class EditClientPageViewModel : ViewModelBase
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
        #region Save
        public DelegateCommand<object> cmdSave { get; private set; }
        async void SaveClient(object parameter)
        {
            await DatabaseService.ClientDatabase.SaveClientAsync(Client);
            await NavigationService.GoBackAsync();
        }
        #endregion
        #region Delete
        public DelegateCommand<object> cmdDelete { get; private set; }
        async void DeleteClient(object parameter)
        {
            await DatabaseService.ClientDatabase.DeleteClientAsync(Client);
            await NavigationService.GoBackToRootAsync();
        }
        #endregion
        #endregion
        public EditClientPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Edit Client";
            #region Delegate Commands
            cmdSave = new DelegateCommand<object>(SaveClient);
            cmdDelete = new DelegateCommand<object>(DeleteClient);
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
