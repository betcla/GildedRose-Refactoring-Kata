using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharpcore
{
    public class BackstageTests
    {
        [Test]
        public void Backstage_QualityIncreasesBy1_ForSellInGreaterThan10()
        {
            var Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(11);
        }

        [Test]
        public void Backstage_QualityIncreasesBy2_ForSellInLessThan10()
        {
            var Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(12);
        }

        [Test]
        public void Backstage_QualityIncreasesBy3_ForSellInLessThan5()
        {
            var Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(13);
        }

        [Test]
        public void Backstage_QualityIsZero_ForSellInLessThanZero()
        {
            var Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }
        
        [Test]
        public void Backstage_Quality_CantBe_GreaterThan50_ForSellInGreaterThan10()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 11, Quality = 50}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }
        
        [Test]
        public void Backstage_Quality_CantBe_GreaterThan50_ForSellInLessThan10()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 10, Quality = 50}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }
        
        [Test]
        public void Backstage_Quality_CantBe_GreaterThan50_ForSellInLessThan5()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 5, Quality = 50}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }
        
        [Test]
        public void Backstage_Quality_CantBe_GreaterThan50_ForSellInLessThan0()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 0, Quality = 50}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }
    }
}