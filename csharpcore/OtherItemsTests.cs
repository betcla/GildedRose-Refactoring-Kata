using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharpcore
{
    public class OtherItemsTests
    {
        /*private readonly AgedBrieTests _agedBrieTests = new AgedBrieTests();
        private readonly BackstageTests _backstageTests = new BackstageTests();*/

        [Test]
        public void Quality_CantBe_NegativeForPositiveSellIn()
        {
            var Items = new List<Item> {new Item {Name = "cheese", SellIn = 5, Quality = 0}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }

        [Test]
        public void Quality_CantBe_NegativeForNegativeSellIn()
        {
            var Items = new List<Item> {new Item {Name = "cheese", SellIn = -1, Quality = 0}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }
        

        [Test]
        public void Quality_Sulfuras_Always80()
        {
            var Items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(80);
        }

        [Test]
        public void Quality_TwiceAsFast_ForNegativeSellIn()
        {
            var Items = new List<Item> {new Item {Name = "cheese", SellIn = 0, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(8);
        }

        [Test]
        public void SellIn_Sulfuras_StaysSame()
        {
            var Items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].SellIn.Should().Be(10);
        }
    }
}