//to return area and perimeter together

(double area, double perimeter) CalculateRectangle(double length, double width)
{
    double area = length * width;
    double perimeter = 2 * (length + width);
    return (area, perimeter);
}
Console.WriteLine("output: tuple implementation"+ CalculateRectangle(5,5));

//pattern matching

object obj = "Nandhini Mogane";
if(obj is string str)
{
    Console.WriteLine($"The string is:{str}");
}
else
{
    Console.WriteLine("the object is not a string");
}

//switch

Console.WriteLine("Enter a value");
object value = Convert.ToInt32(Console.ReadLine());
switch (value)
{
    case int n when n > 0:
        Console.WriteLine("Positive Integer");
        break;

    case int n when n < 0:
        Console.WriteLine("Negative Integer");
        break;

    case string s:
        Console.WriteLine("String value: " + s);
        break;

    case null:
        Console.WriteLine("Value is null");
        break;

    default:
        Console.WriteLine("Unknown Type");
        break;
}
Console.WriteLine("the output of pattern matching with switch statement is " +value);
Console.ReadLine();






