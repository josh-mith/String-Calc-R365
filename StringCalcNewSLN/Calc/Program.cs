using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalcNewSLN
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sProgramDelimiters = Calculator.CustomDelimiter();

            //Prompt user for input
            Console.WriteLine("Which numbers would you like find the sum of?");

            //Collect user input
            string sUserInput = Console.ReadLine();

            //Run Add function w/ user input
            Console.WriteLine(Calculator.Add(sUserInput, sProgramDelimiters));
        }
    }
}
