using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace HomeWork16
{

    [Serializable]
    public class Inventory
    {
        [field : NonSerialized]
        public event Action<string> LogAction;
        public List<ProductClass> Products { get; set; } = new();
        public int Length
        {
            get
            {
                LogAction.Invoke("Получена длина");
                return Products.Count;
            }
        }
        public ProductClass this[int index]
        {
            get
            {
                return Products[index];
            }

            set
            {
                Products[index] = value;
            }
        }
        public ProductClass this[string propName]
        {
            get
            {
                foreach (var person in Products)
                {
                    if (person.Name == propName)
                    {
                        return person;
                    }
                }
                return null;
            }
        }
        public Inventory()
        {
            LogAction += Log.LogEntry;
            LogAction.Invoke($"{DateTime.Now} Создан новый инвентарь");
        }
        public int SumProductPrices(ProductClass product)
        {
            LogAction.Invoke($"{DateTime.Now} получена сумма цен продукта {product}");
            return product.Price * product.Count;
        }

        public void AddNewProduct(ProductClass product)
        {
            Products.Add(product);
            LogAction.Invoke($"{DateTime.Now} Создан новый продукт {product}");
            SaveChanges();
        }
        public void RemoveProduct(int id)
        {
            var productToRemove = Products.Find(prod => prod.Id == id);
            Products.Remove(productToRemove);
            LogAction.Invoke($"{DateTime.Now} Удален продукт {productToRemove}");
            SaveChanges();
        }
        public void ChangeCountProduct(string productName, int value)
        {
            var prodCount = this[productName].Count;
            this[productName].Count = value;
            LogAction.Invoke($"{DateTime.Now} Изменено количество продукта {this[productName]}" +
                $" c {prodCount} на {value}");
            SaveChanges();
        }
        private void SaveChanges()
        {
            using FileStream fs = new("inventory.json", FileMode.OpenOrCreate);
            JsonSerializer.Serialize(fs, this);

            XmlSerializer xmlSerializer = new(typeof(Inventory));
            using FileStream fs2 = new("inventory.xml", FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fs2, this);
        }
    }
}
