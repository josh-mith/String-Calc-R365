﻿using System;
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