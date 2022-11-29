using LambdaUebung;
using System.Runtime.CompilerServices;

namespace LambdaUebung { 
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Beispiel 1: Converter");

            //decimal[] converted = LambdaTest.Converter(new decimal[] { -10, 0, 10, 20, 30 }, CelsiusToKelvin);
            decimal[] converted = LambdaTest.Converter(new decimal[] { -10, 0, 10, 20, 30 }, v => v + 273.15M);

            //LambdaTest.ForEach(converted, PrintValue);
            LambdaTest.ForEach(converted, Console.WriteLine);

            Console.WriteLine("Beispiel 2: Filter");

            //decimal[] freezed = LambdaTest.Filter(converted, WasserGefriert);
            decimal[] freezed = LambdaTest.Filter(converted, v => v < 273.15M);

            //LambdaTest.ForEach(freezed, PrintValue);
            LambdaTest.ForEach(freezed, Console.WriteLine);

            Console.WriteLine("Beispiel 3: Division");

            //decimal result = LambdaTest.ArithmeticOperation(2, 0, DivideSafe);
            decimal result = LambdaTest.ArithmeticOperation(2, 0, (x, y) => y==0? 0 : x/y);
            Console.WriteLine(result);

            //result = LambdaTest.ArithmeticOperation(2, 0, Divide, PrintError);
            result = LambdaTest.ArithmeticOperation(2, 0, (x,y) => x/y, m => Console.WriteLine(m));
            Console.WriteLine(result);

            Console.WriteLine("Beispiel 4: Callback Funktion");

            //LambdaTest.RunCommand(SayHello);
            LambdaTest.RunCommand(() => {
                Console.WriteLine("Hello World.");
                Console.WriteLine("Hello World again.");
                });

            Console.ReadLine();
        }

        //public static decimal CelsiusToKelvin(decimal value) => value + 273.15M;
        
        //public static void PrintValue(decimal value) => Console.WriteLine(value);
        
        //public static decimal Divide(decimal x, decimal y) => x / y;
        
        //public static decimal DivideSafe(decimal x, decimal y) => y==0? 0 : x/y;
        
        //public static void PrintError(string message) => Console.WriteLine(message);

        //public static void SayHello() => Console.WriteLine("Hello World.\nHello World again");
        
        //public static bool WasserGefriert(decimal val) => val < 273.15M;
        
    }
}