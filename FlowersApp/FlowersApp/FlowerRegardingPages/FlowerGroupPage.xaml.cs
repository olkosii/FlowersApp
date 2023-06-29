using FlowersApp.Models;
using FlowersApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlowersApp.FlowerRegardingPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlowerDetailsPage : ContentPage
    {
        public FlowerDetailsPage(IGrouping<string,Flower> flowersGroup)
        {
            InitializeComponent();

            flowersListView.ItemsSource = flowersGroup.OrderBy(f => f.Length);
        }

        private void flowersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}