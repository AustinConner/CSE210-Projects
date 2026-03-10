using System.Drawing;
using System.Runtime.CompilerServices;

class Shape
{
    private string _color;

    //methods


    public Shape(string color)
    {
        SetColor(color);
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    virtual public double GetArea()
    {
        return 1;
    }
}