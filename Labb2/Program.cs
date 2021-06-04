using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
    class CanadaSIN
    {
        public static void Run()
        {
            List<int> num = new List<int>();
            Console.WriteLine("Please enter 9 digits number: ");
            do
            {
                int addNumber = 1;
                try
                {
                    addNumber = Int32.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please don't enter null \n");
                    return;
                }

                if (0 < addNumber && addNumber <= 9)
                {
                    num.Add(addNumber);
                }
                else
                {
                    Console.WriteLine("Exceed number from 1 - 9");
                }
            } while (num.Count <= 8);
            
            //9 digits
            Console.WriteLine("Your SIN: ");
            foreach (int obj in num )
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("");
            
            //add
            int p1 = num[1] + num[1];
            int p2 = num[3] + num[3];
            int p3 = num[5] + num[5];
            int p4 = num[7] + num[7];

            int[] d1 = p1.ToString().ToCharArray().Select(x => (int) Char.GetNumericValue(x)).ToArray();
            int[] d2 = p2.ToString().ToCharArray().Select(x => (int) Char.GetNumericValue(x)).ToArray();
            int[] d3 = p3.ToString().ToCharArray().Select(x => (int) Char.GetNumericValue(x)).ToArray();
            int[] d4 = p4.ToString().ToCharArray().Select(x => (int) Char.GetNumericValue(x)).ToArray();

            int[] Pair;
            Pair = d1.Concat(d2).Concat(d3).Concat(d4).ToArray();
            Console.WriteLine("");

            int totalDigit = Pair.Sum();
            int overDigit = num[0] + num[2] + num[4] + num[6];
            int fTotal = totalDigit + overDigit;
            int temp = 1;
            int hightInteger = 10;
            while (temp * 10 <= fTotal)
            {
                temp++;
            }

            hightInteger *= temp;

            if (hightInteger - fTotal != num[8])
            {
                Console.WriteLine("This is not a valid Sin!");
            }
            else
            {
                Console.WriteLine("This is a valid Sin!");
            }
            Console.WriteLine(""); 
        }
        
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                CanadaSIN.Run();
                Console.WriteLine("Do you want to restart? (Y = 1 - N = 0");
                Console.WriteLine("Your choice:");
                choice = Int32.Parse(Console.ReadLine());
            } while (choice != 0);
        }
    }
}