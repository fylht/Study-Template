using Study.LabWork1.Features.Task2.Abstractions;

namespace Study.LabWork1.Features.Task2.Services
{
    public class OrderFacade
    {
        private IInventory _inventory;
        private IPayment _payment;
        private INotification _notification;
        private IShipping _shipping;

        public OrderFacade(IInventory inventory, IPayment payment, INotification notification, IShipping shipping)
        {
            _inventory = inventory;
            _payment = payment;
            _notification = notification;
            _shipping = shipping;
        }

        public bool PlaceOrder(string product, int quantity, string cardNumber, decimal amount, string addres, string emaill)
        {
            Console.WriteLine("=== Начало оформления заказа ===");

            if(!_inventory.CheckAvailability(product, quantity))
            {
                Console.WriteLine("Ошибка: товар на складе не обнаружен!");
                return false;
            }

            _inventory.Reserve(product, quantity);

            string orderId = Guid.NewGuid().ToString();
            if(!_payment.ProcessPayment(amount, cardNumber))
            {
                Console.WriteLine("Ошибка: платёж не обработался!");
                return false;
            }

            _shipping.CreateLable(orderId, addres, product);
            _shipping.PrintLable(orderId);

            _notification.SendNotifications(emaill);

            Console.WriteLine("=== Заказ успешно оформлен! ===");
            return true;
        }
    }
}
