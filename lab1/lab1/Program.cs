using System;

namespace lab1
{
    class Program
    {
        static bool IsNumbers(String firstValue, String secondValue, String thirdValue)
        {
            return double.TryParse(firstValue, out double n) && double.TryParse(secondValue, out double k) && double.TryParse(thirdValue, out double l);
        }
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("неизвестная ошибка");
            }
            else
            {
                CTriangle triangle = new CTriangle();

                if (!IsNumbers(args[0], args[1], args[2]))
                {
                    Console.WriteLine("неизвестная ошибка");
                }
                else
                {
                    triangle.FirstSide = checked(Convert.ToDouble(args[0]));
                    triangle.SecondSide = checked(Convert.ToDouble(args[1]));
                    triangle.ThirdSide = checked(Convert.ToDouble(args[2]));


                    if (triangle.FirstSide < 0 || triangle.SecondSide < 0 || triangle.ThirdSide < 0)
                    {
                        Console.WriteLine("не треугольник");
                    }
                    else if (triangle.IsTriangle())
                    {
                        Console.WriteLine(triangle.GetTypeTriangle());
                    }
                    else
                    {
                        Console.WriteLine("не треугольник");
                    }
                }
            }
        }
    }
}
