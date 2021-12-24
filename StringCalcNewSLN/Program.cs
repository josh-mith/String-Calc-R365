using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalcNewSLN
{
    public class Program
    {
        private const int I_STARTING_NUM = 0;

        //Function to add user-inputted numbers
        public static int Add(string sInput)
        {
            var aNumbers = sInput.Split(",");
            var iSum = 0;

            if (aNumbers.Length > 2)
            {
                throw new Exception("You cannot add more than 2 numbers in your sum.");
            }

            foreach (var cNumber in aNumbers)
            {
                if (int.TryParse(cNumber, out int iCleanedNumber))
                {
                    iSum += iCleanedNumber;
                }
            }
            return iSum;
        }
        public static void Main(string[] args)
        {
            //Prompt user for input
            Console.WriteLine("Which numbers would you like find the sum of?");

            //Collect user input
            string sUserInput = Console.ReadLine();

            //Run Add function w/ user input
            Console.WriteLine(Add(sUserInput));


        }
    }
}
