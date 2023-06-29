using FlowersApp.Models;
using FlowersApp.Repositories;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowersApp.FlowerRegardingPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlowersPage : ContentPage
    {
        public FlowersPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var flowers = await FlowerRepository.GetDistinctFlowersAsync();

            flowersListView.ItemsSource = flowers;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewFlowerPage());
        }

        private void flowersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(flowersListView.SelectedItem is IGrouping<string,Flower> group)
                Navigation.PushAsync(new FlowerDetailsPage(group));
        }
    }
}