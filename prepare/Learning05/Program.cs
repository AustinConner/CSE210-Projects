using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> myShapes = new List<Shape>();
        Square mySquare = new Square("Red", 4);
        Rectangle myRectangle = new Rectangle("Blue", 10, 14);
        Circle myCircle = new Circle("Purple", 26);

        myShapes.Add(mySquare);
        myShapes.Add(myRectangle);
        myShapes.Add(myCircle);

        foreach (Shape shape in myShapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}. Area: {shape.GetArea()}");
        }
    }
}