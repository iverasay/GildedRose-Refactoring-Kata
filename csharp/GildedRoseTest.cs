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

        [Test]
        public void BackstagePassesItemsQualityAfter5Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage Passes 1", SellIn = 20, Quality = 20 },
                                                 new Item { Name = "Backstage Passes 2", SellIn = 13, Quality = 20 },
                                                 new Item { Name = "Backstage Passes 3", SellIn = 6, Quality = 20 },
                                                 new Item { Name = "Backstage Passes 4", SellIn = 5, Quality = 20 }};

            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < 5; i++) app.UpdateQuality();

            Assert.AreEqual(25, Items[0].Quality);
            Assert.AreEqual(27, Items[1].Quality);
            Assert.AreEqual(34, Items[2].Quality);
            Assert.AreEqual(35, Items[3].Quality);
        }

        [Test]
        public void NonNegativeQualityAfter5Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Prod 1", SellIn = 2, Quality = 5 },
                                                 new Item { Name = "Backstage Passes 2", SellIn = 3, Quality = 10},
                                                 new Item { Name = "Conjured 3", SellIn = 3, Quality = 5 },
                                                 new Item { Name = "Sulfuras 4", SellIn = 3, Quality = 80 }};

            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < 5; i++) app.UpdateQuality();

            Assert.Zero(Items[0].Quality);
            Assert.Zero(Items[1].Quality);
            Assert.Zero(Items[2].Quality);
            Assert.AreEqual(80, Items[3].Quality);
        }

    }
}
