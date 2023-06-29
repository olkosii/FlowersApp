using FlowersApp.Models;
using FlowersApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowersApp.Repositories
{
    public static class ClientRepository
    {
        private static IClientRepository _clientRepository = DependencyService.Get<IClientRepository>();

        public async static Task<List<Client>> GetAllClientsAsync()
        {
            try
            {
                return await _clientRepository.GetClientsAsync();
            }
            catch (Exception ex)
            {
                return new List<Client>();
            }
        }

        public async static Task<bool> AddClientAsync(Client client)
        {
            try
            {
                await _clientRepository.CreateClientAsync(client);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async static Task<bool> UpdateClientAsync(Client client)
        {
            try
            {
                await _clientRepository.UpdateClientAsync(client);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async static Task<bool> DeleteClientAsync(Client client)
        {
            try
            {
                await _clientRepository.DeleteClientAsync(client);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string FormatPhoneNumber(string phoneNumber)
        {
            try
            { 
                if(phoneNumber.Length == 18)
                    return phoneNumber;

                var numberWithoutCC = int.Parse(phoneNumber.Remove(0, 6));
                var formattedNumberWithoutCC = string.Format("{0:## ###-##-##}", numberWithoutCC);
                return "+(380)" + formattedNumberWithoutCC;
            }
            catch (Exception)
            {
                return Helpers.Constants.Messages.incorrectNumber;
            }
        }
    }
}
