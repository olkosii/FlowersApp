using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowersApp.Repositories
{
    public static class AuthRepository
    {
        private static IAuthRepository authRepository = DependencyService.Get<IAuthRepository>();

        public static async Task<bool> RegisterUser(string email, string password)
        {
            try
            {
                return await authRepository.RegisterUser(email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }

        public static async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                return await authRepository.LoginUser(email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }
    }
}
