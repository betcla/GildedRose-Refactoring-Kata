using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharpcore
{
    public class ConjuredTests
    {
        [Test]
        public void Conjured_Quality_CantBe_NegativeForPositiveSellIn()
        {
            var Items = new List<Item> {new Item {Name = "Conjured apples", SellIn = 5, Quality = 0}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }

        [Test]
        public void Conjured_Quality_CantBe_NegativeForNegativeSellIn()
        {
            var Items = new List<Item> {new Item {Name = "Conjured apples", SellIn = -1, Quality = 0}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }

        [Test]
        public void Conjured_Quality_DecreasesByTwo_ForPositiveSellIn()
        {
            var Items = new List<Item> {new Item {Name = "Conjured apples", SellIn = 1, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(8);
        }

        [Test]
        public void Conjured_Quality_TwiceAsFast_ForNegativeSellIn()
        {
            var Items = new List<Item> {new Item {Name = "Conjured apples", SellIn = 0, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(6);
        }
    }
}