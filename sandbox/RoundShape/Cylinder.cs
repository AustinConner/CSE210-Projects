using System.Formats.Asn1;
using System.Runtime.InteropServices;
namespace RoundShape;
class Cylinder : Circle
{
    private double _height;

    public void SetHeight(double height)
    {
        _height = height;
    }

    override public double Area()
    {
         double cylinderArea = (2 * Math.PI) + (_height + _radius);
        return cylinderArea;
    }
}