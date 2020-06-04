using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2a
{
    class Program
    {
        static void Main(string[] args)
        {
            Quadrangle Square = new Quadrangle(new Point(0, 0), new Point(0, 2), new Point(2, 2), new Point(2, 0));
            PrintAboutFigur(Square);
            Square.SaveInFile(@"./Square.txt");

            //Quadrangle Rectangle = new Quadrangle(new Point(0, 0), new Point(0, 3), new Point(4, 3), new Point(4, 0));
            //PrintAboutFigur(Rectangle);

            Console.WriteLine("\n----------------------\n");
            Console.WriteLine("Square from file");
            Quadrangle SquareFromFile = new Quadrangle(@"./Square.txt");
            PrintAboutFigur(SquareFromFile);

            Console.ReadKey();

            void PrintAboutFigur(Quadrangle Figur)
            {
                Console.WriteLine($"Фигура с координатами:\r\n {Figur.FirstPoint}, {Figur.SecondPoint}, {Figur.ThirdPoint}, {Figur.FourthPoint}");
                Console.WriteLine($"Длина сторон:\n {Figur.FirstSide}, {Figur.SecondSide}, {Figur.ThirdSide}, {Figur.FourthSide}");
                Console.WriteLine($"Диагонали:\n {Figur.FirstDiagonal}, { Figur.SecondDiagonal}");
                Console.WriteLine($"Периметр фигуры:\n {Figur.Perimetr}");
                Console.WriteLine($"Площадь фигуры:\n {Figur.Area}");
            }
        }
    }
}
