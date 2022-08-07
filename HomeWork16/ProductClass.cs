using System;

namespace HomeWork16
{
    [Serializable]
    public class ProductClass
    {
        public int Price { get; set; } = 0;
        public int Count { get; set; } = 0;
        private string _name;
        public string Name { get => _name; set => _name = value ?? "default name"; }

        private static int IncrementId = 1;

        private int _thisId = IncrementId;
        public int Id { get => _thisId; }

        public ProductClass()
        {
            ++IncrementId;
        }
        public ProductClass(int price, int count, string name)
        {
            ++IncrementId;
            Name = name;
            Price = price;
            Count = count;
        }
        public override string ToString()
        {
            return $"Name : {Name}, Id : {Id}, Price : {Price}, Count : {Count}";
        }
    }
}
