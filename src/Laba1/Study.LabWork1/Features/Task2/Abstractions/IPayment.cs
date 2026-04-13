using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2.Abstractions
{
    public interface IPayment
    {
        public bool ProcessPayment(decimal amount, string cardNumber);
    }
}
