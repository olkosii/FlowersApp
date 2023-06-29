using FlowersApp.Models;
using FlowersApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlowersApp.Repositories
{
    public class FlowerRepository
    {
        private static IFlowerRepository _flowerRepository = DependencyService.Get<IFlowerRepository>();

        public async static Task<List<IGrouping<string, Flower>>> GetDistinctFlowersAsync()
        {
            try
            {
                return await _flowerRepository.GetFlowersAsync();
            }
            catch (Exception ex)
            {
                return new List<IGrouping<string, Flower>>();
            }
        }

        public async static Task<bool> AddFlowerAsync(Flower flower)
        {
            try
            {
                await _flowerRepository.CreateFlowerAsync(flower);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async static Task<bool> UpdateFlowerAsync(Flower flower)
        {
            try
            {
                await _flowerRepository.UpdateFlowerAsync(flower);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async static Task<bool> DeleteFlowerAsync(Flower flower)
        {
            try
            {
                await _flowerRepository.DeleteFlowerAsync(flower);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
