// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

while (true)
{
    Console.WriteLine("Please input the unit for your Height: 1-m, 2-in");
    string heightUnitStr = Console.ReadLine();
    if (!Calculator.UnitInputValadation(heightUnitStr))
    {
        Console.WriteLine("Incorrect input");
        continue;
    }

    Console.WriteLine("Please input your Height, eg: 1.85");
    string heightStr = Console.ReadLine();
    if (!Calculator.NumberInputValadation(heightStr))
    {
        Console.WriteLine("Incorrect input");
        continue;
    }


    Console.WriteLine("Please input the unit for your Weight: 1-kg, 2-lb");
    string weightUnitStr = Console.ReadLine();
    if (!Calculator.UnitInputValadation(weightUnitStr))
    {
        Console.WriteLine("Incorrect input");
        continue;
    }
    Console.WriteLine("Please input your Weight, eg: 85.5");
    string weightStr = Console.ReadLine();
    if (!Calculator.NumberInputValadation(weightStr))
    {
        Console.WriteLine("Incorrect input");
        continue;
    }




    int heightUnit = Convert.ToInt32(heightUnitStr);
    int weightUnit = Convert.ToInt32(weightUnitStr);
    double height = Convert.ToDouble(heightStr);
    double weight = Convert.ToDouble(weightStr);
    double bmi = Calculator.GetBMI(height, heightUnit, weight, weightUnit);
    Console.WriteLine($"Your BMI is {bmi}");
    Console.ReadLine();

}


public static class Calculator
{

    public static bool UnitInputValadation(string input)
    {
        if(input == "1" || input == "2")
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static bool NumberInputValadation(string input)
    {
       if( Regex.IsMatch(input, @"^\d+\.\d+$"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static double GetBMI(double height, int heightUnit, double weight, int weightUnit)
    {
        double heightInM = heightUnit == 1? height: height*0.0254;
        double weightInKg = weightUnit == 1 ? weight : weight * 0.453;
        double BMI = weightInKg / (heightInM*heightInM);
        return BMI;
    }
}