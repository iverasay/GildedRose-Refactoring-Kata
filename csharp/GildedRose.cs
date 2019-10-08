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
                            if (product.SellIn > 10 && product.Quality < 50)
                                product.Quality++;
                            else if (product.SellIn < 0) // I supposed that the concert is when sellIn is 0
                                product.Quality = 0;
                            else if (product.SellIn <= 5)
                                product.Quality = (product.Quality < 48 ? product.Quality + 3 : 50);
                            else if (product.SellIn <= 10)
                                product.Quality = (product.Quality < 49 ? product.Quality + 2 : 50);
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
