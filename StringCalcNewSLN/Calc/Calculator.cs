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
            var aAllDelimiters = new List<string>();
            var aDefaultDelimiters = new string[2];
            aDefaultDelimiters[0] = ",";
            aDefaultDelimiters[1] = ",";
            aAllDelimiters.Add(aDefaultDelimiters[0]);
            aAllDelimiters.Add(aDefaultDelimiters[1]);

            Console.WriteLine("Enter a new character to use as a custom delimiter, or enter 'n' to skip or exit.");

            //Get user input on custom delimiter option
            var sDelimiterInput = Console.ReadLine();

            if (string.Compare(sDelimiterInput, "n", true) == 0)
            {
                return aAllDelimiters.ToArray();
            }
            //If user doesn't enter 'n'
            else
            {
                var sCustomDelimiter = "";
                var iCount = 2;
                while (sCustomDelimiter != "n")
                {
                    Console.WriteLine("Enter a new character to use as a custom delimiter, or enter 'n' to skip or exit.");

                    sCustomDelimiter = Console.ReadLine();

                    aAllDelimiters.Add(sCustomDelimiter);
                    iCount++;
                }                
                return aAllDelimiters.ToArray();
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
