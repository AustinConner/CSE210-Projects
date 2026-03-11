using System.Net.NetworkInformation;
namespace RoundShape;
class Circle : RoundShape
{
    protected double _radius;



    public override double Area()
    {
        return Math.PI * (_radius * _radius);
    }

    public void SetRadius(double radius)
    {
        _radius = radius;
    }

}