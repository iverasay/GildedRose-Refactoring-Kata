using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{

    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void FiveDayPass()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "prod 1", SellIn = 10, Quality = 0 },
                                                 new Item { Name = "prod 2", SellIn = 5, Quality = 0 },
                                                 new Item { Name = "prod 3", SellIn = 3, Quality = 0 }};

            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < 5; i++) app.UpdateQuality();

            Assert.AreEqual(5, Items[0].SellIn);
            Assert.AreEqual(0, Items[1].SellIn);
            Assert.AreEqual(-2, Items[2].SellIn);
        }

        [Test]
        public void NormalItemsQualityAfter5Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "prod 1", SellIn = 1, Quality = 50 },
                                                 new Item { Name = "prod 2", SellIn = 5, Quality = 10 },
                                                 new Item { Name = "prod 3", SellIn = 3, Quality = 10 }};

            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < 5; i++) app.UpdateQuality();

            Assert.AreEqual(41, Items[0].Quality);
            Assert.AreEqual(5, Items[1].Quality);
            Assert.AreEqual(3, Items[2].Quality);
        }

    }
}
