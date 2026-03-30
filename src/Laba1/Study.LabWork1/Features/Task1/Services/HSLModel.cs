using Study.LabWork1.Features.Task1.Abstractions;

namespace Study.LabWork1.Features.Task1.Services
{
    public class HSLModel : IColorModel
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

        public void IsValid()
        {
            if (Hue < 0 || Hue > 360)
                throw new ArgumentOutOfRangeException(nameof(Hue), "Hue должен быть в диапазоне от 0 до 360.");

            if (Saturation < 0 || Saturation > 100)
                throw new ArgumentOutOfRangeException(nameof(Saturation), "Saturation должен быть в диапазоне от 0 до 100.");

            if (Lightness < 0 || Lightness > 100)
                throw new ArgumentOutOfRangeException(nameof(Lightness), "Lightness должен быть в диапазоне от 0 до 100.");
        }

        public static HSLModel operator +(HSLModel a, HSLModel b)
        {
            int Hue = (a.Hue + b.Hue) % 360;
            int Saturation = Math.Min(a.Saturation + b.Saturation, 100);
            int Lightness = Math.Min(a.Lightness + b.Lightness, 100);

            return new HSLModel(Hue, Saturation, Lightness);
        }

        public static HSLModel operator +(HSLModel a, int scalar)
        {
            if (scalar < 0) return a - (-scalar);

            int Hue = (a.Hue + scalar) % 360;
            int Saturation = Math.Min(a.Saturation + scalar, 100);
            int Lightness = Math.Min(a.Lightness + scalar, 100);

            return new HSLModel(Hue, Saturation, Lightness);
        }

        public static HSLModel operator -(HSLModel a, HSLModel b)
        {
            int Hue = (a.Hue - b.Hue + 360) % 360;
            int Saturation = Math.Max(a.Saturation - b.Saturation, 0);
            int Lightness = Math.Max(a.Lightness - b.Lightness, 0);

            return new HSLModel(Hue, Saturation, Lightness);
        }

        public static HSLModel operator -(HSLModel a, int scalar)
        {
            if (scalar < 0) return a + (-scalar);

            int Hue = (a.Hue - scalar + 360) % 360;
            int Saturation = Math.Max(a.Saturation - scalar, 0);
            int Lightness = Math.Max(a.Lightness - scalar, 0);

            return new HSLModel(Hue, Saturation, Lightness);
        }

        public static HSLModel operator *(HSLModel a, HSLModel b)
        {
            int Hue = (a.Hue * b.Hue) % 360;
            int Saturation = Math.Min(a.Saturation * b.Saturation, 100);
            int Lightness = Math.Min(a.Lightness * b.Lightness, 100);

            return new HSLModel(Hue, Saturation, Lightness);
        }

        public static HSLModel operator *(HSLModel a, int scalar)
        {
            if (scalar < 0) scalar = -scalar;

            int Hue = (a.Hue * scalar) % 360;
            int Saturation = Math.Min(a.Saturation * scalar, 100);
            int Lightness = Math.Min(a.Lightness * scalar, 100);

            return new HSLModel(Hue, Saturation, Lightness);
        }

        public static HSLModel operator /(HSLModel a, int scalar)
        {
            if (scalar == 0) throw new DivideByZeroException();
            if (scalar < 0) scalar = -scalar;

            int Hue = (a.Hue / scalar) % 360;
            int Saturation = a.Saturation / scalar;
            int Lightness = a.Lightness / scalar;

            return new HSLModel(Hue, Saturation, Lightness);
        }

        public static bool operator ==(HSLModel a, HSLModel b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(HSLModel a, HSLModel b) => !(a == b);

        public bool Equals(object obj)
        {
            if (obj is not HSLModel other) return false;
            return Hue == other.Hue && Saturation == other.Saturation && Lightness == other.Lightness;
        }

        public (byte, byte, byte) ToRGB()
        {
            var rgb = (r: 0.0, g: 0.0, b: 0.0);

            double h = this.Hue;
            double s = this.Saturation / 100.0;
            double l = this.Lightness / 100.0;

            double chroma = (1.0 - Math.Abs(2.0 * l - 1.0)) * s;
            double X = chroma * (1 - Math.Abs((h / 60.0) % 2 - 1));

            if (0 <= h && h < 60) rgb = (chroma, X, 0);
            else if (60 <= h && h < 120) rgb = (X, chroma, 0);
            else if (120 <= h && h < 180) rgb = (0, chroma, X);
            else if (180 <= h && h < 240) rgb = (0, X, chroma);
            else if (240 <= h && h < 300) rgb = (X, 0, chroma);
            else if (300 <= h && h <= 360) rgb = (chroma, 0, X);

            double m = l - chroma / 2.0;

            byte R = (byte)Math.Round((rgb.r + m) * 255);
            byte G = (byte)Math.Round((rgb.g + m) * 255);
            byte B = (byte)Math.Round((rgb.b + m) * 255);

            return (R, G, B);
        }

        public string ToHEX()
        {
            var (R, G, B) = this.ToRGB();
            return "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
        }

        public override string ToString() => $"hsl({Hue}, {Saturation}%, {Lightness}%)";


    }

}
