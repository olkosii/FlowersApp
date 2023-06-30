using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowersApp.Models
{
    public class Order
    {
        [Id]
        public string Id { get; set; }
        public string ClientId { get; set; }
        public List<Flower> Flowers { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalFlowersAmount { get; set; }
    }
}
