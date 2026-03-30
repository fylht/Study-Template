using Study.LabWork1.Features.Task2.Services;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() => throw new NotImplementedException();

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() {
        var facade = new OrderFacade(
            new InventoryService(),
            new PaymentService(),
            new NotificationService(),
            new ShippingService()
        );

        var client = new Client(facade);

        client.MakeOrder();
    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
