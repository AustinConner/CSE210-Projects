class Circle : Shape
{
    private double _radius;

    // methods
    override public double GetArea()
    {
        double circleRadius = 3.14 * (_radius * _radius);
        return circleRadius;
    }

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }
} 