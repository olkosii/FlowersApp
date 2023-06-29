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
    public partial class ClientDetailsPage : ContentPage
    {
        private Client _client;
        public ClientDetailsPage(Client client)
        {
            InitializeComponent();

            this._client = client;

            nameEntry.Text = client.Name;
            addressEntry.Text = client.Address;
            phoneNumberEntry.Text = client.PhoneNumber;
        }

        private async void updateButton_Clicked(object sender, EventArgs e)
        {
            await ClientRepository.UpdateClientAsync(new Client()
            {
                Id = _client.Id,
                Name = nameEntry.Text,
                Address = addressEntry.Text,
                PhoneNumber = phoneNumberEntry.Text
            });
            await Navigation.PushAsync(new HomePage());
        }

        private async void deleteButton_Clicked(object sender, EventArgs e)
        {
            await ClientRepository.DeleteClientAsync(new Client()
            {
                Id = _client.Id,
                Name = nameEntry.Text,
                Address = addressEntry.Text,
                PhoneNumber = phoneNumberEntry.Text
            });
            await Navigation.PushAsync(new HomePage());
        }

        private void phoneNumberEntry_Focused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(phoneNumberEntry.Text) ||
                                     phoneNumberEntry.Text.Contains(Helpers.Constants.Messages.incorrectNumber))
                phoneNumberEntry.Text = "+(380)";
        }

        private void phoneNumberEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if (phoneNumberEntry.Text == "+(380)")
                phoneNumberEntry.Text = "";
            else
                phoneNumberEntry.Text = ClientRepository.FormatPhoneNumber(phoneNumberEntry.Text);
        }
    }
}