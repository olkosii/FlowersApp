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
    public partial class NewClientPage : ContentPage
    {
        public NewClientPage()
        {
            InitializeComponent();
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            //do save procedure

            await Navigation.PushAsync(new HomePage());
        }
    }
}