using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Circle : Shape
    {
        private double radius;
        public Circle(string color, double radius) : base(color)
        { 
            this.radius = radius;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Circle has color - {Color}, radius - {radius}");
        }
        public void CalculateArea(double radius)
        {
            if (radius <= 0)
            {
                Console.WriteLine("Incorrect radius");
            }
            Console.WriteLine($"The area of circle is {Math.PI * radius * radius}");
        }
    }
}
