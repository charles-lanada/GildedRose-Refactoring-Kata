using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests
{
    [UseReporter(typeof(RiderReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            Approvals.Verify(output);
        }

        [Fact]
        public void GildedRoseTest()
        {
            var Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            Items.Add(new Item { Name = "bar", SellIn = 1, Quality = 2 });
            var app = new GildedRose(Items);
            app.UpdateQuality();

            var testString = string.Join(Environment.NewLine, app.Items);
            Approvals.Verify(testString);
        }
    }
}