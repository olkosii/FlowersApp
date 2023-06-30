using FlowersApp.Models;
using FlowersApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowersApp.Repositories
{
    public class OrderRepository
    {
        private static IOrderRepository _orderRepository = DependencyService.Get<IOrderRepository>();

        public async static Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                return await _orderRepository.GetOrdersAsync();
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
        }

        public async static Task<bool> AddOrderAsync(Order order)
        {
            try
            {
                await _orderRepository.CreateOrderAsync(order);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async static Task<bool> UpdateOrderAsync(Order order)
        {
            try
            {
                await _orderRepository.UpdateOrderAsync(order);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async static Task<bool> DeleteOrderAsync(Order order)
        {
            try
            {
                await _orderRepository.DeleteOrderAsync(order);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
