using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var heigth = double.Parse(Console.ReadLine());
                var newBox = new Box(length, width, heigth);
                Console.WriteLine(newBox.SurfaceArea());
                Console.WriteLine(newBox.LateralSurfaceArea());
                Console.WriteLine(newBox.Volume());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
