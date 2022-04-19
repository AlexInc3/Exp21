//Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
public class Point
{
     public double X {get;}    // Вводить координаты через пробел, пример: 3 6 8. Мделать что бы координаты принимались через запятую у меня не получилось.
     public double Y {get;}
     public double C {get;}
     public Point(double x, double y, double c)
         => (X, Y, C) = (x, y, c);
     public static readonly char[] separators = {'/', '\\', ' ', '|'}; // Можно изменить список если есть необходимость
     public static Point Parse (string s)
     {
            string [] split = s. Split (separators, StringSplitOptions.RemoveEmptyEntries);
           return new Point (double.Parse (split [0]),  double.Parse (split [1]), double.Parse (split [2]));
     }
     public static bool TryParse (string s, out Point point)
     {
        try
        {
               point = Parse (s);
               return true;
         }
         catch
        {
            point= null;
            return false;
         }
     }
 
    public static double Distance (Point a, Point b)
    {
         double dX = a.X-b.X;
         double dY = a.Y-b.Y;
         double dC = a.C-b.C;
         return Math.Sqrt(dX*dX + dY*dY+dC*dC);
    }
    public double Distance(Point otherPoint)
         => Distance (this, otherPoint);
   public override string ToString ()
     => $"{{X={X}, Y={Y}, C={C}}}";
    
}
class Program 
{
    static void Main(string[] args)
    {
        for(;;)
        {
            try
            {
                Console. Write ("Введите через пробел координаты первой точки: ");
                Point a = Point.Parse(Console.ReadLine());
                Console. Write ("Введите через пробел координаты второй точки: ");
                Point b = Point.Parse(Console.ReadLine());
                Console. WriteLine($"Расстояние от точки {a} до точки {b} равно {a. Distance (b)}");
                break;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Ошибка!Вы ввели не целое число!");
            }
        }
    }
}