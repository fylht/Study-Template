using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Features.Task2.Abstractions
{
    public interface IShipping
    {
        public void CreateLable(string orderId,string addrtes, string namePoduct);
        public void PrintLable(string orderId);
    }
}
