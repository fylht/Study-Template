using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2.Services
{
    internal class Client
    {
        private readonly OrderFacade _orderFacade;

        public Client(OrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public void MakeOrder()
        {
            _orderFacade.PlaceOrder(
                "Ноутбук",
                1,
                "1234-5678-9999",
                1000,
                "Москва",
                "test@mail.com"
            );
        }
    }
}
