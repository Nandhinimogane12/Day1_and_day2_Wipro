//day2
//printing 
using System.Globalization;
using System.Text;

Console.WriteLine("Hii, this is NandhiniMogane");
//adding two numbers without third variable
int n1 = 10;
int n2 = 2;
Console.WriteLine(n1+n2);
//with third variable
int sum = n1 + n2;
Console.WriteLine(sum);
//printing
Console.WriteLine("the sum of two numbers is "+sum);
Console.WriteLine("the sum of "+n1+" and "+n2+" is "+sum );
//user input for adding and product
Console.WriteLine("Enter the first number");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the Second number");
int num2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Sum = " + (num1 + num2));
Console.WriteLine("product = " + (num1 * num2));
//operators
Console.WriteLine(n1-n2);
Console.WriteLine(n1%n2);
Console.WriteLine(n1/n2);
Console.WriteLine(n1++);//print 10 after increment 11[10]
Console.WriteLine(n1--);//11 printed then decremented 10[11]
Console.WriteLine(++n1);//10+1=11; then printed[11]
Console.WriteLine(--n1);//decremented11-1=10; then printed[10]
//+=
int m = 12;
int n = 2;
m+=n;
Console.WriteLine(m);
int? x = null;
int y = x ?? 15;
Console.WriteLine(y);
//if value is not null
int? a = 3;
int b=a ?? 15;
Console.WriteLine(b);
//logical operator
bool c=true;
bool d=false;
if (c && d)
{
    Console.WriteLine("Both need to be true");
}
else
{
    Console.WriteLine("atleast one true");
}
//boxing
Console.WriteLine("Boxing");
int s = 10;
object obj = s;
Console.WriteLine(obj);
//unboxing
Console.WriteLine("unboxing");
int r = (int)obj;
Console.WriteLine(r);
//string and string builder
Console.WriteLine( "String");
string h = "Nandhini";
Console.WriteLine(h);
//String builder
Console.WriteLine("String builder");
StringBuilder sb = new StringBuilder("Nandhini");
sb.Append(" Mogane");
sb.Append(" Wipro_Training");
Console.WriteLine(sb);
//array
//declaration of array
Console.WriteLine( "array");
int[] arr = new int[5];
//int[] arr = new int[] { 1, 2, 3, 4, 5 };
//string []arr=new string[]{"hello","world"};
arr[0] = 1;
arr[1] = 2;
arr[2] = 3;
arr[3] = 4;
arr[4] = 5;
Console.WriteLine(arr[0]);
Console.WriteLine(arr[3]);
//multidimensional array
//Console.WriteLine("two_dimensional array");
//int[,] array = new int[2, 3] { { 1, 2, 3 },{ 4, 5, 6 } };
//three dimensional array
//Console.WriteLine("three_dimensional array");
//int[,,] ar=new int[2, 2, 2]{{1,2},{3,4} },{{5,6},{6,7}};
//fgor loop
int i = 1;
for (i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}





