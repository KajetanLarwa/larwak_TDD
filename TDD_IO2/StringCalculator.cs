using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TDD_IO2
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            
            var isSingleNumber = int.TryParse(numbers, out int singleNumber);
            if (isSingleNumber)
            {
                return singleNumber;
            }

            var delimiters = new char[] {',', '\n'};
            var isStringDelimiter = false;
            var delimitersString = new List<string>();
            if (numbers[0] == '/' && numbers[1] == '/')
            {
                if (numbers[2] == '[')
                {
                    isStringDelimiter = true;
                    int i = 1;
                    while (numbers[i+1] == '[')
                    {
                        var start = i+2;
                        for (i = start; numbers[i] != ']' && i < numbers.Length; i++);
                        if (i == numbers.Length)  
                            throw new Exception();
                        delimitersString.Add(numbers[start..i]);
                    }
                    numbers = numbers[(i + 1)..];
                } else
                {
                    delimiters = new char[] {numbers[2]};
                    numbers = numbers[3..];
                }
            }

            string[] numbersArray;
            if (isStringDelimiter)
            {
                numbersArray = numbers.Split(delimitersString.ToArray(), StringSplitOptions.None);    
            }
            else
            {
                numbersArray = numbers.Split(delimiters);
            }
            int sum;
            bool succ;
            (sum, succ) = SumNumbers(numbersArray);
            if (succ)
            {
                return sum;
            }

            throw new Exception();
        }

        private (int, bool) SumNumbers(string[] numbersArray)
        {
            var sum = 0;
            foreach (var num in numbersArray)
            {
                var result = int.TryParse(num, out int numInt);
                if (!result)
                    return (0, false);
                if (numInt < 0)
                    throw new ArgumentOutOfRangeException();
                if (numInt > 1000)
                    continue;
                sum += numInt;
            }

            return (sum, true);
        }  
    }
}