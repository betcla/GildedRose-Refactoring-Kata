using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharpcore
{
    public class GildedRoseTest
    {
        /*[Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
        }*/

        [Test]
        public void Quality_CantBe_Negative()
        {
            var Items = new List<Item> {new Item {Name = "cheese", SellIn = 5, Quality = 0}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }

        [Test]
        public void Quality_CantBe_GreaterThan50()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 5, Quality = 50}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
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
        public void Quality_AgedBrie_Increases()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 5, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(11);
        }
        
        [Test]
        public void Quality_AgedBrie_Increases_TwiceAsFast_ForNegativeSellIn()
        {
            var Items = new List<Item> {new Item {Name = "Aged Brie", SellIn = 0, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(12);
        }

        [Test]
        public void SellIn_Sulfuras_StaysSame()
        {
            var Items = new List<Item> {new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].SellIn.Should().Be(10);
        }
        
        [Test]
        public void Quality_BackstageIncreasesBy1_ForSellInGreaterThan10()
        {
            var Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(11);
        }
        
        [Test]
        public void Quality_BackstageIncreasesBy2_ForSellInLessThan10()
        {
            var Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(12);
        }
        
        [Test]
        public void Quality_BackstageIncreasesBy3_ForSellInLessThan5()
        {
            var Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(13);
        }
        
        [Test]
        public void Quality_Zero_ForSellInLessThanZero()
        {
            var Items = new List<Item> {new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}};
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }
    }
}