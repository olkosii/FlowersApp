using FlowersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersApp.Repositories.Interfaces
{
    public interface IFlowerRepository
    {
        Task<List<IGrouping<string, Flower>>> GetFlowersAsync();
        Task<bool> CreateFlowerAsync(Flower flower);
        Task<bool> UpdateFlowerAsync(Flower flower);
        Task<bool> DeleteFlowerAsync(Flower flower);
    }
}
