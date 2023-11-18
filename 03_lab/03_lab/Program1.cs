using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatDay1
{
    class WhatDay
    {
        static void Main1(string[] args)
        {
            Console.Write("Please enter a day number between 1 and 365: ");

            if (!int.TryParse(Console.ReadLine(), out int dayNum))
            {
                Console.WriteLine("Wrong day number.");
                return;
            }

            if (dayNum < 0 || dayNum > 365)
            {
                throw new ArgumentOutOfRangeException("Day out of range");
            }

            int monthNum = 0;

   
            foreach(int daysInMonth in DaysInMonths)
            {
                if (dayNum <= daysInMonth)
                {
                    break;
                }
                else
                {
                    dayNum -= daysInMonth;
                    monthNum++;
                }
            }

            string monthName = MonthNames[monthNum];
            Console.WriteLine("{0} {1}", dayNum, monthName);

        }

        static string[] MonthNames
            = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        // Don't modify anything below here
        static System.Collections.ICollection DaysInMonths
            = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    }
}