using FlowersApp.Models;
using FlowersApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowersApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewClientPage : ContentPage
    {
        public NewClientPage()
        {
            InitializeComponent();
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            var client = new Client()
            {
                Name = clientNameEntry.Text,
                Address = addressEntry.Text,
                PhoneNumber = phoneNumberEntry.Text,
            };

            await ClientRepository.AddClientAsync(client);

            await Navigation.PushAsync(new HomePage());
        }

        private void phoneNumberEntry_Focused(object sender, FocusEventArgs e)
        {
            if(string.IsNullOrEmpty(phoneNumberEntry.Text) ||
                                     phoneNumberEntry.Text.Contains(Helpers.Constants.Messages.incorrectNumber))
                phoneNumberEntry.Text = "+(380)";
        }

        private void phoneNumberEntry_Unfocused(object sender, FocusEventArgs e)
        {
            if(phoneNumberEntry.Text == "+(380)")
                phoneNumberEntry.Text = "";
            else
                phoneNumberEntry.Text = ClientRepository.FormatPhoneNumber(phoneNumberEntry.Text);
        }
    }
}