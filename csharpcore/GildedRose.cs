using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public int maximumQuality = 50;
        public int minimumQuality = 0;
        public int sellByDay = 0;
        public int decreaseInQuality = -1;
        public int increaseInQuality = 1;
        public int decreaseInSellIn = -1;
        public int decreaseInQualForConjured_positiveSellIn = -2;
        public int decreaseInQualForConjured_negativeSellIn = -4;
        public readonly UpdatingOtherObject UpdatingOtherObject;
        public readonly UpdatingConjured _updatingConjured;
        public readonly UpdatingBackstage _updatingBackstage;
        public readonly UpdatingAgedBrie _updatingAgedBrie;


        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            UpdatingOtherObject = new UpdatingOtherObject(this);
            _updatingConjured = new UpdatingConjured(this);
            _updatingBackstage = new UpdatingBackstage(this);
            _updatingAgedBrie = new UpdatingAgedBrie(this);
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                if (UpdatingOtherObject.IsSulfuras(item) || (item.Quality > maximumQuality) ||
                    (item.Quality < minimumQuality))
                {
                    continue;
                }

                item.SellIn = item.SellIn + decreaseInSellIn;

                if (csharpcore.UpdatingBackstage.IsBackstage(item))
                {
                    _updatingBackstage.UpdateBackstage(item);
                    continue;
                }

                if (csharpcore.UpdatingAgedBrie.IsAgedBrie(item) && (item.Quality < maximumQuality))
                {
                    _updatingAgedBrie.UpdateAgedBrie(item);
                    continue;
                }

                if (csharpcore.UpdatingConjured.isConjured(item) && (item.Quality > minimumQuality))
                {
                    _updatingConjured.UpdateConjured(item);
                    continue;
                }

                if ((item.Quality > minimumQuality) && (item.Quality < maximumQuality))
                {
                    UpdatingOtherObject.UpdateOtherItem(item);
                }
            }
        }
    }
}