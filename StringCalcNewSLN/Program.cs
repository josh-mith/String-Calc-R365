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
            var aNumbers = sInput.Split(new Char [] {',', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            var iSum = 0;
            List<int> aNegativeNumbers = new List<int>();

            foreach (var cNumber in aNumbers)
            {
                if (int.TryParse(cNumber, out int iCleanedNumber))
                {
                    iSum += iCleanedNumber;
                }
                //Log presence of negative numbers in user input
                if (iCleanedNumber < 0)
                { 
                    aNegativeNumbers.Add(iCleanedNumber);
                }
            }

            if (aNegativeNumbers.Count > 0)
            {
                throw new Exception(string.Format("Your input contained the following invalid negative numbers: {0}. Please try again.", string.Join(",", aNegativeNumbers)));
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
