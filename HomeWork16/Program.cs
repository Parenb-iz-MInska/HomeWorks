using HomeWork16;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

Inventory inventory = new();

/*using (FileStream fs = new FileStream("inventory.json", FileMode.OpenOrCreate))
{
    Console.WriteLine("Download from JSON");
    inventory = await JsonSerializer.DeserializeAsync<Inventory>(fs);
}
Console.WriteLine("-=-=-=-=-=-=-=-=-");
foreach (var item in inventory.Products)
{
    Console.WriteLine(item);
}*/
/*inventory.Products.Add(new ProductClass(1, 1, "hello"));
inventory.Products.Add(new ProductClass(2, 3, "hello"));
inventory.Products.Add(new ProductClass(4, 6, "hello"));*/
BinaryFormatter formatter = new();

Console.WriteLine("Download from binary file");
using (FileStream fs = new("people.dat", FileMode.OpenOrCreate))
{
    inventory = (Inventory)formatter.Deserialize(fs);
}
foreach (var item in inventory.Products)
{
    Console.WriteLine(item);
}