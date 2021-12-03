using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            var items = new List<Item>
            {
                new Item { Name = "foo", SellIn = 0, Quality = 0 },
                new Item { Name = "Aged Brie",  SellIn = 0, Quality = 0}
            };

            var app = new GildedRose.GildedRose(items);
            app.UpdateQuality();

            Assert.Equal("foo", items[0].Name);
            Assert.Equal("Aged Brie", items[1].Name);
            Assert.NotEqual(0, items[1].Quality);
        }

        [Fact]
        public void When_()
        {

        }
    }
}
