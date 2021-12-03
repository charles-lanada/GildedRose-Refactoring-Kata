using System;
using System.Collections.Generic;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    [UseReporter(typeof(RiderReporter))]
    public class ApprovalTest
    {
        // [Fact()]
        // public void ThirtyDays()
        // {
        //     var fakeoutput = new StringBuilder();
        //     Console.SetOut(new StringWriter(fakeoutput));
        //     Console.SetIn(new StringReader("a\n"));
        //
        //     Program.Main(new string[] { });
        //     var output = fakeoutput.ToString();
        //
        //     Approvals.Verify(output);
        // }

        [Fact]
        public void GildedRoseTest()
        {
            var name = new[]
            {
                "Aged Brie",
                "Backstage passes to a TAFKAL80ETC concert",
                "Sulfuras, Hand of Ragnaros",
                "unknown"
            };
            var sellIn = new [] {-1, 0, 11};
            var quality = new [] {0, 49, 50, 1, -1};


            CombinationApprovals.VerifyAllCombinations(DoUpdateQuality, name, sellIn, quality);
        }

        private string DoUpdateQuality(string name, int sellIn, int quality)
        {
            var items = new List<Item>
            {
                new Item { Name = name, SellIn = sellIn, Quality = quality },
            };
            var app = new GildedRose.GildedRose(items);
            app.UpdateQuality();
            var result = string.Join(Environment.NewLine, app.Items);
            return result;
        }
    }
}
