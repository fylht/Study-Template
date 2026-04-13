using Study.LabWork1.Features.Task2.Abstractions;

namespace Study.LabWork1.Features.Task2.Services
{
    internal class PaymentService : IPayment
    {
        public bool ProcessPayment(decimal amount, string cardNumber)
        {
            Console.WriteLine("Обработка платежа...");
            return true;
        }
    }
}
