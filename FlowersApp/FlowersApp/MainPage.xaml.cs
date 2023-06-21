using FlowersApp.Repositories;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowersApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("FlowersApp.Assets.Images.flower-bouquet.png");
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text)) { }
            else
            {
                var loginResult = await AuthRepository.LoginUser(emailEntry.Text, passwordEntry.Text);

                if (loginResult)
                    await Navigation.PushAsync(new HomePage());
            }
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}