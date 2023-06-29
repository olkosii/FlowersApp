using FlowersApp.Models;
using FlowersApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowersApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsPage : ContentPage
    {
        public ClientsPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewClientPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var clients = await ClientRepository.GetAllClientsAsync();

            clientsListView.ItemsSource = clients;
        }

        private void clientsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (clientsListView.SelectedItem is Client client)
                Navigation.PushAsync(new ClientDetailsPage(client));
        }
    }
}