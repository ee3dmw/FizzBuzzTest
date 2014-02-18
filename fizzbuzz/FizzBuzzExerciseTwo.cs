using System.Text;
using NUnit.Framework;

namespace FizzBuzzExerciseTwo
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

            Assert.AreEqual("1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz", result, "Check that the result has been correctly fizzbuzzed");
        }

        [Test]
        public void WhenNormalNumberIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(2, 2);
            Assert.AreEqual("2", result, "Check number is unprocessed");
        }

        [Test]
        public void WhenDivisibleByThreeIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(6, 6);
            Assert.AreEqual("fizz", result, "Check number is fizzed");
        }

        [Test]
        public void WhenDivisibleByFiveIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(10, 10);
            Assert.AreEqual("buzz", result, "Check number is buzzed");
        }

        [Test]
        public void WhenDivisibleByThreeAndFiveIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(15, 15);
            Assert.AreEqual("fizzbuzz", result, "Check number is fizzbuzzed");
        }

        [Test]
        public void WhenNumberContainingThreeIsProcessed()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.CreateFizzBuzzResult(30, 30);
            Assert.AreEqual("lucky", result, "Check number is replaced with lucky");
        }
    }


    public class FizzBuzzer
    {
        public string CreateFizzBuzzResult(int lowerLimit, int upperLimit)
        {
            var result = new StringBuilder();

            for (var i = lowerLimit; i <= upperLimit; i++)
            {
                result.Append(ProcessInteger(i) + " ");
            }

            return result.ToString().TrimEnd();
        }

        static string ProcessInteger(int value)
        {
            if (NumberContainsThree(value))
                return "lucky";
            if (IsDivisibleByThree(value) && IsDivisibleByFive(value))
                return "fizzbuzz";
            if (IsDivisibleByThree(value))
                return "fizz";
            if (IsDivisibleByFive(value))
                return "buzz";

            return value.ToString();
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
