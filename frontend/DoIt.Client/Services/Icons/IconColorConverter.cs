using System;
using System.Globalization;
using System.Linq;

namespace DoIt.Client.Services.Icons
{
    public class IconColorConverter
    {
        // https://codepen.io/sosuke/pen/Pjoqqp
        public dynamic ConvertHexaToCss(string hexaString)
        {
            var rgb = HexToRgb(hexaString);
            var color = new Color(rgb[0], rgb[1], rgb[2]);
            var solver = new Solver(color);
            var result = solver.Solve();

            return result;
        }

        private int[] HexToRgb(string hexString)
        {
            //replace # occurences
            if (hexString.IndexOf('#') != -1)
                hexString = hexString.Replace("#", "");

            int r, g, b = 0;

            r = int.Parse(hexString.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            g = int.Parse(hexString.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            b = int.Parse(hexString.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            return new int[] { r, g, b };
        }
    }

    public class Color
    {
        public double R { get; set; }
        public double G { get; set; }
        public double B { get; set; }

        public Color(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return $"rgb({Math.Round(this.R)}, ${Math.Round(this.G)}, ${Math.Round(this.B)})";
        }


        public void SetRgb(double r, double g, double b)
        {
            this.R = this.Clamp(r);
            this.G = this.Clamp(g);
            this.B = this.Clamp(b);
        }

        public void HueRotate(double angle = 0)
        {
            angle = angle / 180 * Math.PI;
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            this.Multiply(new[] {
                0.213 + cos * 0.787 - sin * 0.213,
                0.715 - cos * 0.715 - sin * 0.715,
                0.072 - cos * 0.072 + sin * 0.928,
                0.213 - cos * 0.213 + sin * 0.143,
                0.715 + cos * 0.285 + sin * 0.140,
                0.072 - cos * 0.072 - sin * 0.283,
                0.213 - cos * 0.213 - sin * 0.787,
                0.715 - cos * 0.715 + sin * 0.715,
                0.072 + cos * 0.928 + sin * 0.072,
            });
        }

        public void GrayScale(int value = 1)
        {
            this.Multiply(new[] {
                0.2126 + 0.7874 * (1 - value),
                0.7152 - 0.7152 * (1 - value),
                0.0722 - 0.0722 * (1 - value),
                0.2126 - 0.2126 * (1 - value),
                0.7152 + 0.2848 * (1 - value),
                0.0722 - 0.0722 * (1 - value),
                0.2126 - 0.2126 * (1 - value),
                0.7152 - 0.7152 * (1 - value),
                0.0722 + 0.9278 * (1 - value),
            });
        }

        public void Sepia(double value = 1)
        {
            this.Multiply(new[] {
                0.393 + 0.607 * (1 - value),
                0.769 - 0.769 * (1 - value),
                0.189 - 0.189 * (1 - value),
                0.349 - 0.349 * (1 - value),
                0.686 + 0.314 * (1 - value),
                0.168 - 0.168 * (1 - value),
                0.272 - 0.272 * (1 - value),
                0.534 - 0.534 * (1 - value),
                0.131 + 0.869 * (1 - value),
            });
        }

        public void Saturate(double value = 1)
        {
            this.Multiply(new[] {
                0.213 + 0.787 * value,
                0.715 - 0.715 * value,
                0.072 - 0.072 * value,
                0.213 - 0.213 * value,
                0.715 + 0.285 * value,
                0.072 - 0.072 * value,
                0.213 - 0.213 * value,
                0.715 - 0.715 * value,
                0.072 + 0.928 * value,
            });
        }

        public void Multiply(double[] matrix)
        {
            var newR = this.Clamp(this.R * matrix[0] + this.G * matrix[1] + this.B * matrix[2]);
            var newG = this.Clamp(this.R * matrix[3] + this.G * matrix[4] + this.B * matrix[5]);
            var newB = this.Clamp(this.R * matrix[6] + this.G * matrix[7] + this.B * matrix[8]);

            this.R = newR;
            this.G = newG;
            this.B = newB;
        }

        public void Brightness(double value = 1)
        {
            this.Linear(value);
        }

        public void Contrast(double value = 1)
        {
            this.Linear(value, -(0.5 * value) + 0.5);
        }

        public void Linear(double slope = 1, double intercept = 0)
        {
            this.R = this.Clamp(this.R * slope + intercept * 255);
            this.G = this.Clamp(this.G * slope + intercept * 255);
            this.B = this.Clamp(this.B * slope + intercept * 255);
        }

        public void Invert(double value = 1)
        {
            this.R = this.Clamp((value + this.R / 255 * (1 - 2 * value)) * 255);
            this.G = this.Clamp((value + this.G / 255 * (1 - 2 * value)) * 255);
            this.B = this.Clamp((value + this.B / 255 * (1 - 2 * value)) * 255);
        }

        public dynamic Hsl()
        {
            // Code taken from https://stackoverflow.com/a/9493060/2688027, licensed under CC BY-SA.
            var r = this.R / 255;
            var g = this.G / 255;
            var b = this.B / 255;
            var max = Math.Max(Math.Max(r, g), b);
            var min = Math.Min(Math.Min(r, g), b);
            var h = (max + min) / 2;
            var s = (max + min) / 2;
            var l = (max + min) / 2;


            if (max == min)
            {
                h = s = 0;
            }
            else
            {
                var d = max - min;
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
                if (max == R)
                {
                    h = (g - b) / d + (g < b ? 6 : 0);
                }
                else if (max == G)
                {
                    h = (b - r) / d + 2;
                }
                else if (max == B)
                {
                    h = (r - g) / d + 4;
                }

                h /= 6;
            }

            return new
            {
                H = h * 100,
                S = s * 100,
                L = l * 100,
            };
        }

        public double Clamp(double value)
        {
            if (value > 255)
            {
                value = 255;
            }
            else if (value < 0)
            {
                value = 0;
            }
            return value;
        }
    }

    public class Solver
    {
        private Color target;
        private dynamic targetHSL;

        public Color ReusedColor { get; }

        public Solver(Color target) //, Color baseColor)
        {
            this.target = target;
            this.targetHSL = target.Hsl();
            this.ReusedColor = new Color(0, 0, 0);
        }

        public dynamic Solve()
        {
            var result = this.SolveNarrow(this.SolveWide());
            return new
            {
                Values = result.values,
                Loss = result.loss,
                Filter = this.Css(result.values),
            };
        }

        public dynamic SolveWide()
        {
            var A = 5;
            var c = 15;
            var a = new[] { 60, 180, 18000, 600, 1.2, 1.2 };

            var best = new { Loss = double.MaxValue };
            for (var i = 0; best.Loss > 25 && i < 3; i++)
            {
                var initial = new double[] { 50, 20, 3750, 50, 100, 100 };
                var result = this.Spsa(A, a, c, initial, 1000);
                if (result.Loss < best.Loss)
                {
                    best = result;
                }
            }
            return best;
        }

        public dynamic SolveNarrow(dynamic wide)
        {
            var A = wide.Loss;
            var c = 2;
            var A1 = A + 1;
            var a = new double[] { 0.25 * A1, 0.25 * A1, A1, 0.25 * A1, 0.2 * A1, 0.2 * A1 };
            return this.Spsa(A, a, c, wide.Values, 500);
        }

        public dynamic Spsa(double A, double[] a, double c, double[] values, double iters)
        {
            var alpha = 1;
            var gamma = 0.16666666666666666;

            double[]? best = null;
            var bestLoss = double.MaxValue;
            var deltas = new double[6];
            var highArgs = new double[6];
            var lowArgs = new double[6];

            for (var k = 0; k < iters; k++)
            {
                var ck = c / Math.Pow(k + 1, gamma);
                for (var i = 0; i < 6; i++)
                {
                    Random random = new Random();
                    deltas[i] = random.Next() > 0.5 ? 1 : -1;
                    highArgs[i] = values[i] + ck * deltas[i];
                    lowArgs[i] = values[i] - ck * deltas[i];
                }

                var lossDiff = this.Loss(highArgs) - this.Loss(lowArgs);
                for (var i = 0; i < 6; i++)
                {
                    var g = lossDiff / (2 * ck) * deltas[i];
                    var ak = a[i] / Math.Pow(A + k + 1, alpha);
                    values[i] = fix(values[i] - ak * g, i);
                }

                var loss = this.Loss(values);
                if (loss < bestLoss)
                {
                    best = values.Skip(1).Take(values.Length - 1).ToArray();
                    bestLoss = loss;
                }
            }
            return new { Values = best, Loss = bestLoss };


        }

        public double fix(double value, int idx)
        {
            var max = 100;
            if (idx == 2 /* saturate */)
            {
                max = 7500;
            }
            else if (idx == 4 /* brightness */ || idx == 5 /* contrast */)
            {
                max = 200;
            }

            if (idx == 3 /* hue-rotate */)
            {
                if (value > max)
                {
                    value %= max;
                }
                else if (value < 0)
                {
                    value = max + value % max;
                }
            }
            else if (value < 0)
            {
                value = 0;
            }
            else if (value > max)
            {
                value = max;
            }
            return value;
        }

        public double Loss(Double[] filters)
        {
            // Argument is array of percentages.
            var color = this.ReusedColor;
            color.SetRgb(0, 0, 0);

            color.Invert(filters[0] / 100);
            color.Sepia(filters[1] / 100);
            color.Saturate(filters[2] / 100);
            color.HueRotate(filters[3] * 3.6);
            color.Brightness(filters[4] / 100);
            color.Contrast(filters[5] / 100);

            var colorHSL = color.Hsl();
            return (
              Math.Abs(color.R - this.target.R) +
              Math.Abs(color.G - this.target.G) +
              Math.Abs(color.B - this.target.B) +
              Math.Abs(colorHSL.H - this.targetHSL.H) +
              Math.Abs(colorHSL.S - this.targetHSL.S) +
              Math.Abs(colorHSL.L - this.targetHSL.L)
            );
        }

        public string Css(double[] filters)
        {
            double multiplier = 1;

            return $"filter: invert(${ Math.Round(filters[0] * multiplier)}%) sepia(${ Math.Round(filters[1] * multiplier)}%) saturate(${ Math.Round(filters[2] * multiplier)}%) hue - rotate(${ Math.Round(filters[3] * 3.6)} deg) brightness(${ Math.Round(filters[4] * multiplier)}%) contrast(${ Math.Round(filters[5] * multiplier)}%);";

        }
    }
}
