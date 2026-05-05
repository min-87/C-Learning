using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Shape
    {
        private string? color;
        private double area = 0;

        public Shape(string color) 
        { 
            this.color = color;
        }
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                this.color = value;
            }
        }
        public double Area 
        { 
            get 
            { 
                return area;
            }
            set
            {
                this.area = value;
            }
        }
        public void DisplayInfo(string color)
        {
            Console.WriteLine("Color of Shape");
        }
        public void CalculateArea()
        {
            Console.WriteLine("Shape");
        }
    }
}
