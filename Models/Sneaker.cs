namespace SneakerApi.core.Models
{
    public class Sneaker
    {
        public int ID{get; set;}
        public string Brand{get; set;} = string.Empty;
        public string Model{get; set;}= string.Empty;
        public string Color{get; set;}= string.Empty;
        public decimal Price {get; set;}
        public bool InStock{get; set;}
    }
}