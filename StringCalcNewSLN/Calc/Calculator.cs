using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StringCalcNewSLN
{
    public class Calculator
    {
        public static string[] CustomDelimiter()
        {
            var aAllDelimiters = new string[3];
            aAllDelimiters[0] =  ",";
            aAllDelimiters[1] = "\n";

            Console.WriteLine("Press 'y' to create a custom delimiter or press 'n' to skip.");

            //Get user input on custom delimiter option
            var sDelimiterInput = Console.ReadLine();

            if (string.Compare(sDelimiterInput, "n", true) == 0)
            {
                return aAllDelimiters;
            }
            //If user doesn't enter 'n'
            else
            {
                var sCustomDelimiter = "";
                while (sCustomDelimiter == "")
                {
                    Console.WriteLine("Enter a character to use as a custom delimiter. Please only enter one character.");

                    var sPotentialDelimiter = Console.ReadLine();
                    sCustomDelimiter = Console.ReadLine();

                    //Check to see if delimiter is a single character
                    if (sPotentialDelimiter.Length == 1)
                    {
                        sCustomDelimiter = sPotentialDelimiter;
                        aAllDelimiters[2] = sCustomDelimiter;
                    }
                    else
                    {
                        Console.WriteLine("You must include only a single character.");
                    }

                }                
                return aAllDelimiters;
            }
        }

        //Function to add user-inputted numbers
        public static int Add(string sInput, string[] sDelimiters)
        {
            var aNumbers = sInput.Split(sDelimiters, StringSplitOptions.RemoveEmptyEntries);
            var iSum = 0;
            List<int> aNegativeNumbers = new List<int>();
            
            //Maximum and minimum values for acceptable numbers
            int iFloor = 0;
            int iCeiling = 1000;

            foreach (var cNumber in aNumbers)
            {
                //Clean data
                if (int.TryParse(cNumber, out int iCleanedNumber) && iCeiling > iCleanedNumber)
                {
                    iSum += iCleanedNumber;
                }

                //Log presence of negative numbers in user input
                if (iCleanedNumber < iFloor)
                {
                    aNegativeNumbers.Add(iCleanedNumber);
                }
            }

            //Throw exception upon user submitting negative values for addition
            if (aNegativeNumbers.Count > 0)
            {
                throw new Exception(string.Format("Your input contained the following invalid negative numbers: {0}. Please try again.", string.Join(",", aNegativeNumbers)));
            }

            return iSum;
        }
    }
}
