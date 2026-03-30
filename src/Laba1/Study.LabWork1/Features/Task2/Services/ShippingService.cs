using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork1.Features.Task2.Abstractions;

namespace Study.LabWork1.Features.Task2.Services
{
    internal class ShippingService : IShipping
    {
        public void CreateLable(string orderId, string addrtes, string namePoduct) {
            Console.WriteLine("Создание этикетки...");
        }
        public void PrintLable(string orderId)
        {
            Console.WriteLine("Печать этикетки...");
        }
    }
}
