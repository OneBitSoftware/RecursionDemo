namespace RecursionDemo
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            string secretCode = "1122";
            string key = "A1B12C11D2";

            for (int i = 0; i < 10000; i++)
            {
                EncodedMessageHelper.ExecuteCipherLogic(secretCode, key).ToArray();
            }

            //Console.WriteLine("Results:");

            //if (possibleMessages.Any()) // don't use count
            //{
            //    Console.WriteLine(string.Join(Environment.NewLine, possibleMessages));
            //}
        }

        private static string AskForKey()
        {
            Console.WriteLine("Please provide a key:");
            return Console.ReadLine();
        }

        private static string AskForSecret()
        {
            Console.WriteLine("Please provide a secret:");
            return Console.ReadLine();
        }
    }
}