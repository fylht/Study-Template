using System;
using System.Collections.Generic;
using System.Text;

namespace Study.LabWork1.Shared.Abstractions
{
    public interface IColorModel
    {
        public string ToString();
        private void IsValid();
    }
}
