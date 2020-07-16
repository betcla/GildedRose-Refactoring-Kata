using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharpcore
{
    public class AgedBrieTests
    {
        [Test]
        public void AgedBrie_QualityIncreases()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 5, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(11);
        }

        [Test]
        public void AgedBrie_QualityIncreases_TwiceAsFast_ForNegativeSellIn()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 0, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(12);
        }
        
        [Test]
        public void AgedBrie_Quality_CantBe_GreaterThan50()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 5, Quality = 50}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }
    }
}