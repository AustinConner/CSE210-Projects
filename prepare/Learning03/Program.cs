using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.InteropServices;
Fraction test1 = new Fraction(); // 1/1
Display(test1);

Fraction test2 = new Fraction(5); // 5/1
Display(test2);

Fraction test3 = new Fraction(3, 4); // 3/4
Display(test3);


// random fractions
Random randomNumber = new Random();
Fraction test5 = new Fraction();

Console.WriteLine("========= Random Fractions =========");
for (int i = 0; i < 20; i++)
{
    int top = randomNumber.Next(1, 11);
    int bottom = randomNumber.Next(1, 11);
    test5.SetTopNumber(top);
    test5.SetBottomNumber(bottom);
    Display(test5);
}

static void Display(Fraction fractionObject)
{
    string fractionStr = $"Fraction: {fractionObject.GetFractionString()}";
    string fractionDec = $"Decimal: {fractionObject.GetDecimalValue()}";

    Console.WriteLine(fractionStr);
    Console.WriteLine(fractionDec);
    Console.WriteLine();
}
