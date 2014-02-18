using System;


namespace fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzzer = new FizzBuzzExerciseThree.FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(1, 20);
            Console.WriteLine(result.ProcessedFizzBuzzText);
            Console.WriteLine("fizz: " + result.FizzCount);
            Console.WriteLine("buzz: " + result.BuzzCount);
            Console.WriteLine("fizzbuzz: " + result.FizzBuzzCount);
            Console.WriteLine("lucky: " + result.LuckyCount);
            Console.WriteLine("integer: " + result.IntegerCount);
            Console.ReadLine();
        }
    }
}
