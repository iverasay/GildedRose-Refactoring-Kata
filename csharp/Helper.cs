using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class Helper
    {
        public enum ProductType
        {
            Normal = 0,
            Sulfuras = 1,
            AgedBrie = 2,
            BackstagePasses = 3,
            Conjured = 4
        }

        public static int GetProductType(string productName)
        {
            if (productName.ToLower().Contains("sulfuras")) return (int)ProductType.Sulfuras;
            if (productName.ToLower().Contains("aged brie")) return (int)ProductType.AgedBrie;
            if (productName.ToLower().Contains("backstage passes")) return (int)ProductType.BackstagePasses;
            if (productName.ToLower().Contains("conjured")) return (int)ProductType.Conjured;
            return (int)ProductType.Normal;
        }
    }
}
