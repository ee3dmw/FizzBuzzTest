using System;
using System.Text;
using NUnit.Framework;

namespace FizzBuzzExerciseThree
{
    public class FizzBuzzerTests
    {
        [Test]
        public void WhenASequenceIsFizzBuzzed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var lowerLimit = 1;
            var upperLimit = 20;

            var result = fizzBuzzer.CreateFizzBuzzResult(lowerLimit, upperLimit);

            Assert.AreEqual(
                "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz", 
                result.ProcessedFizzBuzzText, 
                "Check that the result has been correctly fizzbuzzed");
            Assert.AreEqual(4, result.FizzCount, "Check the number of fizzes");
            Assert.AreEqual(3, result.BuzzCount, "Check the number of buzzes");
            Assert.AreEqual(1, result.FizzBuzzCount, "Check the number of fizzbuzzes");
            Assert.AreEqual(2, result.LuckyCount, "Check the number of luckies");
            Assert.AreEqual(10, result.IntegerCount, "Check the number of integers");
        }

        [Test]
        public void WhenNormalNumberIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(2, 2).ProcessedFizzBuzzText;
            Assert.AreEqual("2", result, "Check number is unprocessed");
        }

        [Test]
        public void WhenDivisibleByThreeIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(6, 6).ProcessedFizzBuzzText;
            Assert.AreEqual("fizz", result, "Check number is fizzed");
        }

        [Test]
        public void WhenDivisibleByFiveIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(10, 10).ProcessedFizzBuzzText;
            Assert.AreEqual("buzz", result, "Check number is buzzed");
        }

        [Test]
        public void WhenDivisibleByThreeAndFiveIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(15, 15).ProcessedFizzBuzzText;
            Assert.AreEqual("fizzbuzz", result, "Check number is fizzbuzzed");
        }

        [Test]
        public void WhenNumberContainingThreeIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(30, 30).ProcessedFizzBuzzText;
            Assert.AreEqual("lucky", result, "Check number is replaced with lucky");
        }
    }
  
    public class FizzBuzzResult
    {
        private readonly StringBuilder _processedFizzBuzzText;

        public FizzBuzzResult()
        {
            _processedFizzBuzzText = new StringBuilder();
        }
        public int FizzCount { get; set; }
        public int BuzzCount { get; set; }
        public int FizzBuzzCount { get; set; }
        public int LuckyCount { get; set; }
        public int IntegerCount { get; set; }
        public string ProcessedFizzBuzzText 
        { 
            get { return _processedFizzBuzzText.ToString().TrimEnd(); }
        }

        public void AppendValue(string value)
        {
            IntegerCount++;
            _processedFizzBuzzText.Append(value + " ");
        }

        public void AppendLucky()
        {
            LuckyCount++;
            _processedFizzBuzzText.Append("lucky ");
        }

        public void AppendFizz()
        {
            FizzCount++;
            _processedFizzBuzzText.Append("fizz ");
        }
        public void AppendFizzBuzz()
        {
            FizzBuzzCount++;
            _processedFizzBuzzText.Append("fizzbuzz ");
        }
        public void AppendBuzz()
        {
            BuzzCount++;
            _processedFizzBuzzText.Append("buzz ");
        }
    }

    public class FizzBuzzer
    {
        public FizzBuzzResult CreateFizzBuzzResult(int lowerLimit, int upperLimit)
        {
            var result = new FizzBuzzResult();

            for (var i = lowerLimit; i <= upperLimit; i++)
            {
                ProcessInteger(i, result);
            }

            return result;
        }

        static void ProcessInteger(int value, FizzBuzzResult result)
        {
            if (NumberContainsThree(value))
            {
                result.AppendLucky();
                return;
            }
            if (IsDivisibleByThree(value) && IsDivisibleByFive(value))
            {
                result.AppendFizzBuzz();
                return;
            }
            if (IsDivisibleByThree(value))
            {
                result.AppendFizz();
                return;
            }
            if (IsDivisibleByFive(value))
            {
                result.AppendBuzz();
                return;
            }

            result.AppendValue(value.ToString());
        }

        static bool NumberContainsThree(int value)
        {
            return value.ToString().Contains("3");
        }

        static bool IsDivisibleByThree(int value)
        {
            return value % 3 == 0;
        }

        static bool IsDivisibleByFive(int value)
        {
            return value % 5 == 0;
        }
    }
}
