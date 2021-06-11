using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Sin validator");
            Console.WriteLine("==============");
            while (true)
            {
                Console.WriteLine("SIN (0 to quit):");
                var sin = Console.ReadLine();
                if (sin != null && sin.Equals("0"))
                {
                    Console.WriteLine("Have a nice day!");
                    break;
                }
                else
                {
                    Console.WriteLine(CheckValidSin(sin) ? "This is a valid SIN." : "This is not a valid SIN");
                }
            }
        }

        public static bool CheckValidSin(string sin)
        {

            int lastNumber = 0;
            var totalEvenLineNumber = 0;
            var totalOddLineNumber = 0;
            //chuyển chuỗi thành mảng các char
            var sinCharArray = sin.ToCharArray();
            int[] numberOfSin = new int[9]; //khởi tạo mảng 9 số
            int currentIndexOfNumberArray = 0;
            for (int i = 0; i < sinCharArray.Length; i++)
            {
                //kh khởi tạo thì bỏ qua 
                if (sinCharArray[i].ToString().Trim().Length == 0)
                {
                    continue;
                }

                numberOfSin[currentIndexOfNumberArray] = Convert.ToInt32(sinCharArray[i].ToString());
                currentIndexOfNumberArray++;
            }
            lastNumber = numberOfSin[currentIndexOfNumberArray - 1];

            for (int i = 0; i < numberOfSin.Length - 1; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    totalOddLineNumber += numberOfSin[i];
                }
                else
                {
                    var doubleOdNumber = numberOfSin[i] * 2;
                    var charArray = doubleOdNumber.ToString().ToCharArray();
                    for (int j = 0; j < charArray.Length; j++)
                    {
                        totalEvenLineNumber += Convert.ToInt32(charArray[j].ToString());
                    }
                }

                Console.WriteLine(numberOfSin[i]);
            }

            Console.WriteLine($"last number = {lastNumber}");

            var total2line = totalOddLineNumber + totalEvenLineNumber;
            var nextHighestNumberEndingInZero = Math.Ceiling(Convert.ToDouble(total2line) / 10) * 10;
            if (Math.Abs(nextHighestNumberEndingInZero - total2line - lastNumber) == 0)
            {
                return true;
            }

            return false;
        }
    }
}