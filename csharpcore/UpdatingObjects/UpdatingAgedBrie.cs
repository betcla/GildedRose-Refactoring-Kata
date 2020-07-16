namespace csharpcore
{
    public class UpdatingAgedBrie
    {
        private GildedRose _gildedRose;

        public UpdatingAgedBrie(GildedRose gildedRose)
        {
            _gildedRose = gildedRose;
        }

        public static bool IsAgedBrie(Item item)
        {
            return item.Name.Contains("Aged Brie");
        }

        public void UpdateAgedBrie(Item item)
        {
            item.Quality = item.Quality + _gildedRose.increaseInQuality;
            if (item.SellIn < _gildedRose.sellByDay)
            {
                item.Quality = item.Quality + _gildedRose.increaseInQuality;
            }
        }
    }
}