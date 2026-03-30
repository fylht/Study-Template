using System;
using System.Collections.Generic;
using System.Text;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services
{
    internal class RGBModel : IColorModel
    {
        private int R { get; }
        private int G { get; }
        private int B { get; }


        public RGBModel(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
            IsValid();
        }

        private void IsValid()
        {
            if (R < 0 || R > 360)
                throw new ArgumentOutOfRangeException(nameof(R), "R должен быть в диапазоне от 0 до 255.");

            if (G < 0 || G > 100)
                throw new ArgumentOutOfRangeException(nameof(G), "G должен быть в диапазоне от 0 до 255.");

            if (B < 0 || B > 100)
                throw new ArgumentOutOfRangeException(nameof(B), "B должен быть в диапазоне от 0 до 255.");
        }

        public override string ToString()
        {
            return $"hsl({R}, {G}%, {B}%)";
        }
    }
}
