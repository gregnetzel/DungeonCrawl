namespace DungeonCrawl.Models
{
    public class Item 
	{
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int StrValue { get; set; }
        public int DexValue { get; set; }
        public int SpdValue { get; set; }
        public int HPValue { get; set; }
        public string Image { get; set; }
    }
}
