namespace Task2;

class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle("Red", 3.5, 2);
        rectangle.DisplayInfo();
        rectangle.CalculateArea(3.5, 2);

        Circle circle = new Circle("Yellow", 3);
        circle.DisplayInfo();
        circle.CalculateArea(3);
    }
}

