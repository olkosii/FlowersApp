using Android.App;
using FlowersApp.Droid.Dependencies;
using FlowersApp.Models;
using FlowersApp.Repositories.Interfaces;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Gms.Common.Apis.Api;

[assembly: Dependency(typeof(FlowersApp.Droid.Dependencies.FlowerRepositoryDroid))]
namespace FlowersApp.Droid.Dependencies
{
    public class FlowerRepositoryDroid : IFlowerRepository
    {
        public async Task<List<IGrouping<string,Flower>>> GetFlowersAsync()
        {
            try
            {
                var flowersList = (await CrossCloudFirestore.Current
                                                 .Instance
                                                 .Collection("flowers")
                                                 .GetAsync())
                                                 .ToObjects<Flower>()
                                                 .ToList();

                var result = flowersList.GroupBy(f => f.TypeName).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return new List<IGrouping<string, Flower>>();
            }
        }

        public async Task<bool> CreateFlowerAsync(Flower flower)
        {
            try
            {
                await CrossCloudFirestore.Current
                         .Instance
                         .Collection("flowers")
                         .AddAsync(new Flower()
                         {
                             TypeName = flower.TypeName,
                             Length = flower.Length,
                             CountPerPackage = flower.CountPerPackage,
                             PricePerUnit = flower.PricePerUnit,
                             Image = flower.Image,
                         });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFlowerAsync(Flower flower)
        {
            try
            {
                await CrossCloudFirestore.Current
                         .Instance
                         .Collection("flowers")
                         .Document(flower.Id)
                         .DeleteAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateFlowerAsync(Flower flower)
        {
            try
            {
                await CrossCloudFirestore.Current
                    .Instance
                    .Collection("flowers")
                    .Document(flower.Id)
                    .UpdateAsync(new Flower()
                    {
                        TypeName = flower.TypeName,
                        Length = flower.Length,
                        CountPerPackage = flower.CountPerPackage,
                        PricePerUnit = flower.PricePerUnit,
                        Image = flower.Image,
                    });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}