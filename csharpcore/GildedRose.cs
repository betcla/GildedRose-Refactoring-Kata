using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        private int maximumQuality = 50;
        private int minimumQuality = 0;
        private int sellByDay = 0;
        private int decreaseInQuality = -1;
        private int increaseInQuality = 1;
        private int decreaseInSellIn = -1;
        private int decreaseInQualForConjured_positiveSellIn = -2;
        private int decreaseInQualForConjured_negativeSellIn = -4;


        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                if (IsSulfuras(item)/*||(item.Quality == maximumQuality)||(item.Quality == minimumQuality)*/)
                {
                    continue;
                }

                item.SellIn = item.SellIn + decreaseInSellIn;

                if (IsAgedBrie(item) && (item.Quality < maximumQuality))
                {
                    UpdateAgedBrie(item);
                    continue;
                }

                if (IsBackstage(item))
                {
                    UpdateBackstage(item);
                    continue;
                }

                if (isConjured(item) && (item.Quality > minimumQuality))
                {
                    UpdateConjured(item);
                    continue;
                }
                
                if ((item.Quality > minimumQuality) && (item.Quality < maximumQuality))
                {
                    UpdateOtherItem(item);
                }
            }
        }

        private static bool isConjured(Item item)
        {
            return item.Name.Contains("Conjured");
        }

        private static bool IsBackstage(Item item)
        {
            return item.Name.Contains("Backstage");
        }

        private static bool IsAgedBrie(Item item)
        {
            return item.Name.Contains("Aged Brie");
        }

        private static bool IsSulfuras(Item item)
        {
            return item.Name.Contains("Sulfuras");
        }

        private void UpdateOtherItem(Item item)
        {
            item.Quality = item.Quality + decreaseInQuality;
            if ((item.SellIn < sellByDay) && (item.Quality > minimumQuality))
            {
                item.Quality = item.Quality + decreaseInQuality;
            }
        }

        private void UpdateConjured(Item item)
        {
            if (item.SellIn >= sellByDay)
            {
                UpdateConjuredForPositiveSellIn(item);
            }
            else
            {
                UpdateConjuredForNegativeSellIn(item);
            }
        }

        private void UpdateConjuredForNegativeSellIn(Item item)
        {
            if (item.Quality <= Math.Abs(decreaseInQualForConjured_negativeSellIn))
            {
                item.Quality = minimumQuality;
            }
            else
            {
                item.Quality = item.Quality + decreaseInQualForConjured_negativeSellIn;
            }
        }

        private void UpdateConjuredForPositiveSellIn(Item item)
        {
            if (item.Quality < Math.Abs(decreaseInQualForConjured_positiveSellIn))
            {
                item.Quality = minimumQuality;
            }
            else
            {
                item.Quality = item.Quality + decreaseInQualForConjured_positiveSellIn;
            }
        }

        private void UpdateBackstage(Item item)
        {
            if ((item.Quality < maximumQuality) && (item.SellIn >= sellByDay))
            {
                UpdateBackstageForPositiveSellIn(item);
            }
            else if (item.SellIn < sellByDay)
            {
                item.Quality = minimumQuality;
            }
        }

        private void UpdateBackstageForPositiveSellIn(Item item)
        {
            item.Quality = item.Quality + 1;
            if ((item.Quality < maximumQuality) && (item.SellIn < 10))
            {
                item.Quality = item.Quality + 1;
                if ((item.Quality < maximumQuality) && (item.SellIn < 5))
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        private void UpdateAgedBrie(Item item)
        {
            item.Quality = item.Quality + increaseInQuality;
            if (item.SellIn < sellByDay)
            {
                item.Quality = item.Quality + increaseInQuality;
            }
        }
    }
}