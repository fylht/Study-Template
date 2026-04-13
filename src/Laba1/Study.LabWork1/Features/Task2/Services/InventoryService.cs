using Study.LabWork1.Features.Task2.Abstractions;

namespace Study.LabWork1.Features.Task2.Services
{
    internal class InventoryService : IInventory
    {
        public bool CheckAvailability(string product, int quantity)
        {
            Console.WriteLine("Проверка наличия товара на складе...");
            return true;
        }

        public void Reserve(string product, int quantity)
        {
            Console.WriteLine("Резервирование товара...");
        }
    }
}
