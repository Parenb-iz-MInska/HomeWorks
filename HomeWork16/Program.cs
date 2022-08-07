using HomeWork16;

Inventory inventory = new();
inventory.AddNewProduct(new ProductClass(3, 3, "hello"));
inventory.AddNewProduct(new ProductClass(3, 3, "Hello2"));
inventory.ChangeCountProduct("hello", 99);
Console.WriteLine($"сумма цен продукта {inventory[0]} - {inventory.SumProductPrices(inventory[0])}");
foreach (var item in Log.LogInfo)
{
    Console.WriteLine(item);
}