using HomeWork16;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

Inventory inventory = new();

using (FileStream fs = new FileStream("inventory.json", FileMode.OpenOrCreate))
{
    Console.WriteLine("Download from JSON");
    inventory = await JsonSerializer.DeserializeAsync<Inventory>(fs);
}
Console.WriteLine("-=-=-=-=-=-=-=-=-");
foreach (var item in inventory.Products)
{
    Console.WriteLine(item);
}
