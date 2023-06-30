using FlowersApp.Models;
using FlowersApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FlowersApp.OrdersRegardingPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderPage : ContentPage
    {
        private static List<Flower> _flowerListForClient;
        public List<Flower> FlowerList;
        public NewOrderPage()
        {
            InitializeComponent();
            //var e = flowersGroup.Where(g => g.Key == "Explorer").FirstOrDefault().ToList();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var clients = await ClientRepository.GetAllClientsAsync();
            var flowersGroup = await FlowerRepository.GetDistinctFlowersAsync();

            clientPicker.ItemsSource = clients;
            flowersListView.ItemsSource = flowersGroup;
        }
    }
}