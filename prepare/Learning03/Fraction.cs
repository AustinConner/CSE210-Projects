using System.Net.Http.Headers;

public class Fraction
{
    private int _topNumber;
    private int _bottomNumber;

    // constructors
    public Fraction()
    {
        SetTopNumber(1);
        SetBottomNumber(1);
    }

    public Fraction(int topNumber)
    {
        SetTopNumber(topNumber);
        SetBottomNumber(1);
    }

    public Fraction(int topNumber, int bottomNumber)
    {
       SetTopNumber(topNumber);
       SetBottomNumber(bottomNumber);
    }

    // methods
    public void SetTopNumber(int number)
    {
        _topNumber = number;
    }

    public void SetBottomNumber(int number)
    {
        _bottomNumber = number;
    }

    public string GetFractionString()
    {
        return $"{_topNumber}/{_bottomNumber}";
    }

    public double GetDecimalValue()
    {
        return (double)_topNumber / (double)_bottomNumber;
    }

    public int GetTopNumber()
    {
        return _topNumber;
    }

    public int GetBottomNumber()
    {
        return _bottomNumber;
    }


}