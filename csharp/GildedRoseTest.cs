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

    }
}
