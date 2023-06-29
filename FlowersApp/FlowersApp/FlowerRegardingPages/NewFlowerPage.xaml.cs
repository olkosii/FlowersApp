using FlowersApp.Models;
using FlowersApp.Repositories;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowersApp.FlowerRegardingPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewFlowerPage : ContentPage
    {
        public NewFlowerPage()
        {
            InitializeComponent();
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            Flower flower = null;
            try
            {
                flower = new Flower()
                {
                    TypeName = typeNameEntry.Text,
                    Length = double.Parse(lengthEntry.Text),
                    CountPerPackage = int.Parse(countPerPackageEntry.Text),
                    PricePerUnit = decimal.Parse(pricePerUnitEntry.Text),
                    Image = imageEntry.Text,
                };
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Information is not on the valid format", "Ok");
            }
            finally
            {
                await FlowerRepository.AddFlowerAsync(flower);

                await Navigation.PushAsync(new HomePage());
            }
        }
    }
}