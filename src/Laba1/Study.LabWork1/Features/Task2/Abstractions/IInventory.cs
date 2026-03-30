using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2.Abstractions
{
    public interface IInventory
    {
        public bool CheckAvailability(string product, int quantity);

        public void Reserve(string product, int quantity);
    }
}
