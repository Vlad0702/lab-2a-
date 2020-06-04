using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2a
{
    class Quadrangle
    {
        public Quadrangle(Point firstPoint, Point secondPoint, Point thirdPoint, Point fourthPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            ThirdPoint = thirdPoint;
            FourthPoint = fourthPoint;
        }

        public Quadrangle(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    Regex regex = new Regex(@"(\d+, \d+)");
                    MatchCollection points = regex.Matches(sr.ReadToEnd());
                    FirstPoint = new Point(points[0].ToString());
                    SecondPoint = new Point(points[1].ToString());
                    ThirdPoint = new Point(points[2].ToString());
                    FourthPoint = new Point(points[3].ToString());
                    Console.WriteLine(ThirdPoint);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex);
            }
        }


        public Point FirstPoint { get; }
        public Point SecondPoint { get; }
        public Point ThirdPoint { get; }
        public Point FourthPoint { get; }
        public double FirstSide
        {
            get
            {
                return Math.Abs(LengthCalc(FirstPoint, SecondPoint));
            }
        }
        public double SecondSide
        {
            get
            {
                return Math.Abs(LengthCalc(SecondPoint, ThirdPoint));
            }
        }
        public double ThirdSide
        {
            get
            {
                return Math.Abs(LengthCalc(ThirdPoint, FourthPoint));
            }
        }
        public double FourthSide
        {
            get
            {
                return Math.Abs(LengthCalc(FourthPoint, FirstPoint));
            }
        }
        public double FirstDiagonal
        {
            get
            {
                return Math.Abs(LengthCalc(FirstPoint, ThirdPoint));
            }
        }
        public double SecondDiagonal
        {
            get
            {
                return Math.Abs(LengthCalc(SecondPoint, FourthPoint));
            }
        }
        public double Perimetr
        {
            get
            {
                return FirstSide + SecondSide + ThirdSide + FourthSide;
            }
        }
        public double Area
        {
            get
            {
                double halfPerimeter = Perimetr / 2;

                return Math.Sqrt((halfPerimeter - FirstSide) * (halfPerimeter - SecondSide) *
                                 (halfPerimeter - ThirdSide) * (halfPerimeter - FourthSide)); 
            }
        }

        public void SaveInFile (string path)
        {
            string text = $"Фигура с координатами:\n {FirstPoint}, {SecondPoint}, {ThirdPoint}, {FourthPoint}\n" +
                          $"Длина сторон:\n {FirstSide}, {SecondSide}, {ThirdSide}, {FourthSide}\n" +
                          $"Диагонали:\n {FirstDiagonal}, { SecondDiagonal}" +
                          $"Периметр фигуры: { Perimetr}\n" +
                          $"Площадь фигуры:\n {Area}";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public double LengthCalc(Point FirstPoint, Point SecondPoint)
        {
            return (Math.Sqrt(Math.Pow(SecondPoint.X - FirstPoint.X, 2) + (Math.Pow(SecondPoint.Y  - FirstPoint.Y, 2))));
        }
    }
}
