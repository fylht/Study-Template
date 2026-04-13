using Moq;
using Study.LabWork1.Features.Task2.Abstractions;
using Study.LabWork1.Features.Task2.Services;

namespace Study.LabWork1.Tests.Features.Task2.Services
{
    [TestFixture]
    public class OrderFacadeTests
    {
        private Mock<IInventory> _inventoryMock;
        private Mock<IPayment> _paymentMock;
        private Mock<INotification> _notificationMock;
        private Mock<IShipping> _shippingMock;
        private OrderFacade _orderFacade;

        [SetUp]
        public void SetUp()
        {
            _inventoryMock = new Mock<IInventory>();
            _paymentMock = new Mock<IPayment>();
            _notificationMock = new Mock<INotification>();
            _shippingMock = new Mock<IShipping>();

            _orderFacade = new OrderFacade(
                _inventoryMock.Object,
                _paymentMock.Object,
                _notificationMock.Object,
                _shippingMock.Object);
        }

        [Test]
        public void PlaceOrder_WhenAllStepsSucceed_ReturnsTrue()
        {
         
            _inventoryMock
                .Setup(x => x.CheckAvailability("Ноутбук", 1))
                .Returns(true);

            _paymentMock
                .Setup(x => x.ProcessPayment(1000m, "1234-5678-9999"))
                .Returns(true);

          
            bool result = _orderFacade.PlaceOrder(
                "Ноутбук",
                1,
                "1234-5678-9999",
                1000m,
                "Москва",
                "test@mail.com");

        
            Assert.That(result, Is.True);

            _inventoryMock.Verify(x => x.CheckAvailability("Ноутбук", 1), Times.Once);
            _inventoryMock.Verify(x => x.Reserve("Ноутбук", 1), Times.Once);
            _paymentMock.Verify(x => x.ProcessPayment(1000m, "1234-5678-9999"), Times.Once);

            _shippingMock.Verify(
                x => x.CreateLable(It.IsAny<string>(), "Москва", "Ноутбук"),
                Times.Once);

            _shippingMock.Verify(
                x => x.PrintLable(It.IsAny<string>()),
                Times.Once);

            _notificationMock.Verify(
                x => x.SendNotifications("test@mail.com"),
                Times.Once);
        }

        [Test]
        public void PlaceOrder_WhenProductIsNotAvailable_ReturnsFalse()
        {
       
            _inventoryMock
                .Setup(x => x.CheckAvailability("Ноутбук", 1))
                .Returns(false);

    
            bool result = _orderFacade.PlaceOrder(
                "Ноутбук",
                1,
                "1234-5678-9999",
                1000m,
                "Москва",
                "test@mail.com");

    
            Assert.That(result, Is.False);

            _inventoryMock.Verify(x => x.CheckAvailability("Ноутбук", 1), Times.Once);
            _inventoryMock.Verify(x => x.Reserve(It.IsAny<string>(), It.IsAny<int>()), Times.Never);
            _paymentMock.Verify(x => x.ProcessPayment(It.IsAny<decimal>(), It.IsAny<string>()), Times.Never);
            _shippingMock.Verify(x => x.CreateLable(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            _shippingMock.Verify(x => x.PrintLable(It.IsAny<string>()), Times.Never);
            _notificationMock.Verify(x => x.SendNotifications(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void PlaceOrder_WhenPaymentFails_ReturnsFalse()
        {
      
            _inventoryMock
                .Setup(x => x.CheckAvailability("Ноутбук", 1))
                .Returns(true);

            _paymentMock
                .Setup(x => x.ProcessPayment(1000m, "1234-5678-9999"))
                .Returns(false);

     
            bool result = _orderFacade.PlaceOrder(
                "Ноутбук",
                1,
                "1234-5678-9999",
                1000m,
                "Москва",
                "test@mail.com");

           
            Assert.That(result, Is.False);

            _inventoryMock.Verify(x => x.CheckAvailability("Ноутбук", 1), Times.Once);
            _inventoryMock.Verify(x => x.Reserve("Ноутбук", 1), Times.Once);
            _paymentMock.Verify(x => x.ProcessPayment(1000m, "1234-5678-9999"), Times.Once);

            _shippingMock.Verify(x => x.CreateLable(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            _shippingMock.Verify(x => x.PrintLable(It.IsAny<string>()), Times.Never);
            _notificationMock.Verify(x => x.SendNotifications(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void PlaceOrder_WhenCalled_InvokesAllRequiredServices()
        {
            
            _inventoryMock
                .Setup(x => x.CheckAvailability(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(true);

            _paymentMock
                .Setup(x => x.ProcessPayment(It.IsAny<decimal>(), It.IsAny<string>()))
                .Returns(true);

         
            _orderFacade.PlaceOrder(
                "Ноутбук",
                1,
                "1234-5678-9999",
                1000m,
                "Москва",
                "test@mail.com");

      
            _inventoryMock.Verify(x => x.CheckAvailability(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            _inventoryMock.Verify(x => x.Reserve(It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            _paymentMock.Verify(x => x.ProcessPayment(It.IsAny<decimal>(), It.IsAny<string>()), Times.Once);
            _shippingMock.Verify(x => x.CreateLable(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            _shippingMock.Verify(x => x.PrintLable(It.IsAny<string>()), Times.Once);
            _notificationMock.Verify(x => x.SendNotifications(It.IsAny<string>()), Times.Once);
        }
    }
}
