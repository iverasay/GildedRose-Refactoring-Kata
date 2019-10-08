using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item product in Items)
            {
                product.SellIn--;
                int productType = Helper.GetProductType(product.Name);

                if (product.Quality >= 0 && product.Quality <= 50 && productType != (int)Helper.ProductType.Sulfuras)
                {

                    switch (productType)
                    {
                        case (int)Helper.ProductType.AgedBrie:
                            if (product.Quality < 50) product.Quality++;
                            break;

                        case (int)Helper.ProductType.BackstagePasses:                          
                            break;

                        case (int)Helper.ProductType.Conjured:
                            break;

                        case (int)Helper.ProductType.Normal:
                            if (product.Quality > 0) product.Quality--;
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}
