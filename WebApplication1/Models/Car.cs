namespace WebApplication1.Models
{
    public class Car
    {
        private static int _globalId = 0;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Color { get; set; } = string.Empty;
        public Car()
        {
            Id = _globalId;
            ++_globalId;
        }
        public Car(string name, int price, string color)
        {
            Id = _globalId;
            Name = name;
            Price = price;
            Color = color;
            _globalId++;
        }
    }
}
