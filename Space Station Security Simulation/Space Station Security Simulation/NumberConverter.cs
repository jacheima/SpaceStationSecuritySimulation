using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Station_Security_Simulation
{
    public enum ConvertFrom
    {
        binary, hex, deci
    }

    public enum ConvertTo
    {
        binary, hex, deci
    }

    public class NumberConverter
    {
        public ConvertFrom convertFrom;
        public ConvertTo convertTo;

        /// <summary>
        /// Checks which number type it should convert to and returns the converted number.
        /// </summary>
        /// <param name="numberToConvert"></param>
        /// <returns></returns>
        public int ConvertFromBinary(string numberToConvert)
        {
            //create the converted number variable that will hold the converted number
            int convertedNumber = 0;

            //if we are converting to decimal
            if(convertTo == ConvertTo.deci)
            {
                //set the converted number to the number returned by the Binary To Decimal Property.
                convertedNumber = ConvertBinaryToDecimal(numberToConvert);
            }

            //return the value of converted number
            return convertedNumber;

        }

        /// <summary>
        /// Converts a base 10 number to a base 2 number
        /// </summary>
        /// <param name="numberToConvert"></param>
        /// <returns></returns>
        public List<string> ConvertDecimalToBinary(int numberToConvert)
        {
            //create a new list to hold each number of the binary number
            List<string> binaryNumber = new List<string>();

            //set up a number to convert from decimal to binary
            int num = numberToConvert;

            //set up a number that will hold the number we are dividing
            int temp = numberToConvert;

            //set up an int that will hold the number we will be dividing by
            int dividingNumber = 0;

            //an int that allows us to determine how many digits are in the number we are converting
            string number = temp.ToString();

            //int that holds the digits in the number we are converting
            //and the number of digits in our binary number
            int digitCount = number.Length;

            //calculate the possible numbers
            double possibilities = Math.Pow(10, digitCount);

            //find the lowest power of two that is greater than the possibile numbers
            for (double i = 0; i < possibilities; i++)
            {
                //check if the power of two is greater than or equal to the possiblile numbers
                if(Math.Pow(2, i) >= possibilities)
                {
                    //set digit count to i, because i is the number of digits in our binary number
                    digitCount = (int)i;

                    //break out of the for loop because we don't need to continue it
                    break;

                }
            }

            //set the dividing number, 2 to the power on the number of digits
            dividingNumber = (int)Math.Pow(2, digitCount);

            //starting from the left most digit, loop through all the digits
            for(int i = digitCount; i > -1; i--)
            {
                //divide the current temp by the dividing number, will be 1.xxx or 0.xxxx
                //since these are ints, it will chop off the .xxx's so temp will equal 1 or 0
                temp /= dividingNumber;

                //add the number to the binary number list
                binaryNumber.Add(temp.ToString());

                //if the number we just added to the list is 1
                if (binaryNumber[digitCount - i] == "1")
                {
                    //reduce the current number by the dividing number
                    num -= dividingNumber;

                    //set temp to the new number we will be dividing
                    temp = num;

                    //calculate the new dividing number (2 to the power of the next digit)
                    dividingNumber /= 2;
                    
                }
                //if the number we just added to the list is 0
                else if (binaryNumber[digitCount - i] == "0")
                {
                    //add the number we just divided to the temp value
                    temp += num;

                    //calculate the new dividing number (2 to the power of the next digit)
                    dividingNumber /= 2;
                }
            }

            //return the list of digits
            return binaryNumber;
        
        }

        /// <summary>
        /// Takes the binary number and converts it to base 10 (decimal).
        /// </summary>
        /// <param name="numberToConvert"></param>
        /// <returns></returns>
        public int ConvertBinaryToDecimal(string numberToConvert)
        {
            //create a new list of characters that will hold the digits of the binary number
            List<char> binaryNumber = new List<char>();

            //create the number variable that will hold the converted value of the binary number
            int number = 0;

            //convert the number to convert to string
            string numberString = numberToConvert.ToString();

            //get the number of digits of the number
            int digitCount = numberString.Length;

            //add each character of the binary number(numberToConvert) string to the list of binary number characters
            for(int i = 0; i < numberString.Length; i++)
            {
                //add the value to the list of characters
                binaryNumber.Add(numberString[i]);
            }

            //starting at the left most digit
            for(int i = binaryNumber.Count - 1; i > 0; i--)
            {
                //if the value of the current digit is 1
                if(binaryNumber[i] == '1')
                {
                    //add 2^n to the number 
                    number += (int)Math.Pow(2, i);
                }
            }

            //return the converted number
            return number;

        }

        
    }
}
