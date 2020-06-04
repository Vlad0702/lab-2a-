using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2a
{
    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(string point)
        {
            try
            {
                Regex regex = new Regex(@"\d+");
                MatchCollection numbers = regex.Matches(point);
                X = Convert.ToInt32(numbers[0].ToString());
                Y = Convert.ToInt32(numbers[1].ToString());
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public int X { get; }
        public int Y { get; }
    }
}
