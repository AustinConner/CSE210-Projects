using System.Formats.Asn1;
using System.Runtime.CompilerServices;
namespace RoundShape;
class Sphere : Circle
{
    override public double Area()
    {
        double Area = 2.0 * Math.PI * base.Area();
        return Area;
    }
}