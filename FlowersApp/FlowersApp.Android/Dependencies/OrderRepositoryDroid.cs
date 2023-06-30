using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlowersApp.Models;
using FlowersApp.Repositories.Interfaces;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FlowersApp.Droid.Dependencies.OrderRepositoryDroid))]
namespace FlowersApp.Droid.Dependencies
{
    public class OrderRepositoryDroid : IOrderRepository
    {
        public async Task<bool> CreateOrderAsync(Order order)
        {
            try
            {
                await CrossCloudFirestore.Current
                         .Instance
                         .Collection("orders")
                         .AddAsync(new Order()
                         {
                             ClientId = order.ClientId,
                             Flowers = order.Flowers,
                             TotalFlowersAmount = order.TotalFlowersAmount,
                             TotalPrice = order.TotalPrice,
                         });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}