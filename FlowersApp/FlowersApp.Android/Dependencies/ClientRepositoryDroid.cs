using Android.App;
using Android.Content;
using Android.OS;

using FlowersApp.Models;
using FlowersApp.Repositories.Interfaces;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FlowersApp.Droid.Dependencies.ClientRepositoryDroid))]
namespace FlowersApp.Droid.Dependencies
{
    public class ClientRepositoryDroid : IClientRepository
    {
        public async Task<List<Client>> GetClientsAsync()
        {
            try
            {
                var clientsList = (await CrossCloudFirestore.Current
                                                 .Instance
                                                 .Collection("clients")
                                                 .GetAsync())
                                                 .ToObjects<Client>()
                                                 .ToList();

                return clientsList;
            }
            catch (Exception ex)
            {
                return new List<Client>();
            }
            
        }

        public async Task<bool> CreateClientAsync(Client client)
        {
            try
            {
                await CrossCloudFirestore.Current
                         .Instance
                         .Collection("clients")
                         .AddAsync(new Client()
                         {
                             Name = client.Name,
                             Address = client.Address,
                             PhoneNumber = client.PhoneNumber,
                         });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            try
            {
                await CrossCloudFirestore.Current
                    .Instance
                    .Collection("clients")
                    .Document(client.Id)
                    .UpdateAsync(new Client()
                    {
                        Name = client.Name,
                        Address = client.Address,
                        PhoneNumber = client.PhoneNumber,
                    });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteClientAsync(Client client)
        {
            try
            {
                await CrossCloudFirestore.Current
                         .Instance
                         .Collection("clients")
                         .Document(client.Id)
                         .DeleteAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}