using Plugin.CloudFirestore.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowersApp.Models
{
    public class Flower
    {
        [Id]
        public string Id { get; set; }
        public string TypeName { get; set; }
        public double Length { get; set; }
        public int CountPerPackage { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Image { get; set; }
    }
}
