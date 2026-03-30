using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services
{
    internal class HSLModel : IColorModel
    {
        public int Hue { get; }
        public int Saturation { get; }
        public int Lightness { get; }

        public HSLModel(int hue, int saturation, int lightness)
        {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;

            IsValid();
        }
        public HSLModel(HSLModel pixel)
        {
            Hue = pixel.Hue;
            Saturation = pixel.Saturation;
            Lightness = pixel.Lightness;

            IsValid();
        }

        private void IsValid()
        {
            if (Hue < 0 || Hue > 360)
                throw new ArgumentOutOfRangeException(nameof(Hue), "Hue должен быть в диапазоне от 0 до 360.");

            if (Saturation < 0 || Saturation > 100)
                throw new ArgumentOutOfRangeException(nameof(Saturation), "Saturation должен быть в диапазоне от 0 до 100.");

            if (Lightness < 0 || Lightness > 100)
                throw new ArgumentOutOfRangeException(nameof(Lightness), "Lightness должен быть в диапазоне от 0 до 100.");
        }

        public static HSLModel operator +(HSLModel obj1, HSLModel obj2)
        {
            int Hue = (obj1.Hue + obj2.Hue) % 360;
            int Saturations = Math.Min(obj1.Saturation + obj2.Saturation, 100);
            int Lightness = Math.Min(obj1.Lightness + obj2.Lightness, 100);

           return new HSLModel(Hue, Saturations, Lightness);
        }

        public static HSLModel operator +(HSLModel obj1, int scalar)
        {
            if (scalar < 0) return obj1 - (scalar * -1); 

            int Hue = (obj1.Hue + scalar) % 360;
            int Saturations = Math.Min(obj1.Saturation + scalar, 100);
            int Lightness = Math.Min(obj1.Lightness + scalar, 100);

            return new HSLModel(Hue, Saturations, Lightness);
        }

        public static HSLModel operator -(HSLModel obj1, HSLModel obj2)
        {
            int Hue = Math.Abs(obj1.Hue - obj2.Hue);
            int Saturations = Math.Max(obj1.Saturation - obj2.Saturation, 0);
            int Lightness = Math.Max(obj1.Lightness - obj2.Lightness, 0);

            return new HSLModel(Hue, Saturations, Lightness);
        }

        public static HSLModel operator -(HSLModel obj1, int scalar)
        {
            if(scalar < 0) return obj1 + (scalar * -1);

            int Hue = Math.Abs((obj1.Hue - scalar) % 360);
            int Saturations = Math.Max(obj1.Saturation - scalar, 0);
            int Lightness = Math.Max(obj1.Lightness - scalar, 0);

            return new HSLModel(Hue, Saturations, Lightness);
        }

        public static HSLModel operator *(HSLModel obj1, HSLModel obj2)
        {
            int Hue = (obj1.Hue * obj2.Hue) % 360;
            int Saturations = Math.Min(obj1.Saturation * obj2.Saturation, 100);
            int Lightness = Math.Min(obj1.Lightness * obj2.Lightness, 100);

            return new HSLModel(Hue, Saturations, Lightness);
        }

        public static HSLModel operator *(HSLModel obj1, int scalar)
        {
            if (scalar < 0) scalar *= -1;

            int Hue = (obj1.Hue * scalar) % 360;
            int Saturations = Math.Min(obj1.Saturation * scalar, 100);
            int Lightness = Math.Min(obj1.Lightness * scalar, 0);

            return new HSLModel(Hue, Saturations, Lightness);
        }

        public static HSLModel operator /(HSLModel obj1, int scalar)
        {
            if (scalar < 0) scalar *= -1;

            int Hue = (obj1.Hue * scalar) % 360;
            int Saturations = Math.Min(obj1.Saturation * scalar, 100);
            int Lightness = Math.Min(obj1.Lightness * scalar, 100);


            return new HSLModel(Hue, Saturations, Lightness);
        }

        public static bool operator ==(HSLModel obj1, HSLModel obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(HSLModel obj1, HSLModel obj2)
        {
            return !obj1.Equals(obj2);
        }

        public (byte, byte, byte) ToRGB(HSLModel pixel)
        {
            var rgb = (r: 0,g: 0,b: 0);
            int chroma = (1 - Math.Abs(pixel.Lightness * 2 - 1)) * pixel.Saturation;
            int Hue = pixel.Hue / 60;
            int X = chroma * (1 - Math.Abs(Hue % 2 - 1));
            
            if (0 <= X && X <= 1) rgb = (chroma, X, 0);
            else if (1 <= X && X <= 2) rgb = (X, chroma, 0);
            else if (2 <= X && X <= 3) rgb = (0, chroma, X);
            else if (3 <= X && X <= 4) rgb = (0, X, chroma);
            else if (4 <= X && X <= 5) rgb = (X, 0, chroma);
            else if (5 <= X && X <= 6) rgb = (chroma, 0, X);

            int m = pixel.Lightness - chroma / 2;
            byte R = (byte)((rgb.r + m) * 255);
            byte G = (byte)((rgb.g + m) * 255);
            byte B = (byte)((rgb.b + m) * 255);

            return (R, G, B);
        }

        public 


        public override string ToString()
        {
            return $"hsl({Hue}, {Saturation}%, {Lightness}%)";
        }


    }

}
