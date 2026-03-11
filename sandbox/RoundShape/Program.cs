using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Xml;

namespace RoundShape;

class Program
{
    static void Main(string[] args)
    {
        // Circle
        Circle steve = new Circle();
        steve.SetRadius(2.0);

        // Cylinder
        Cylinder mike = new Cylinder();
        mike.SetRadius(10.0);
        mike.SetHeight(2.0);

        // Sphere
        Sphere sully = new Sphere();
        sully.SetRadius (500);

        Console.WriteLine(steve.Area());
        Console.WriteLine(mike.Area());
        Console.WriteLine(sully.Area());
    
    }
}
