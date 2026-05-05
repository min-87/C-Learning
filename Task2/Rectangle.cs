using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Rectangle : Shape
    {
        private double Width;
        private double Length;

        public Rectangle(string color, double width, double length) : base(color)
        {
            Width = width;
            Length = length;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Rectangle has color - {Color}, width - {Width}, Length - {Length}");
        }
        public  void CalculateArea(double width, double length)
        {
            if (width <= 0 || length <= 0)
            {
                Console.WriteLine("Incorrect width or length");
            }
            Console.WriteLine($"The area of rectangle is {width * length}"); 
        }
        
    }
}
