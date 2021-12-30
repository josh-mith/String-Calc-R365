using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalcNewSLN
{
    public class Calculator
    {
        //Function to add user-inputted numbers
        public static int Add(string sInput)
        {
            var aNumbers = sInput.Split(new Char[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
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
