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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailEntry.Text) ||
                string.IsNullOrEmpty(passwordEntry.Text) ||
                string.IsNullOrEmpty(confirmPasswordEntry.Text)) 
            {
                await App.Current.MainPage.DisplayAlert("Hint", "Please fill all entries", "Ok");
            }
            else
            {
                if(!passwordEntry.Text.Equals(confirmPasswordEntry.Text))
                    await App.Current.MainPage.DisplayAlert("Error", "Passwords are not the same", "Ok");


                var registerResult = await AuthRepository.RegisterUser(emailEntry.Text, passwordEntry.Text);

                if (registerResult)
                    await Navigation.PushAsync(new HomePage());
            }
        }
    }
}