using System;

namespace Shooting
{
    class WhatDay
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Enter a year: ");
            if (!int.TryParse(Console.ReadLine(), out int yearNum))
            {
                Console.WriteLine("Invalid year format.");
                return;
            }

            bool isLeapYear = DateTime.IsLeapYear(yearNum);
            int maxDayNum = isLeapYear ? 366 : 365;

            Console.WriteLine("Please enter a day number between 1 and {0}: ", maxDayNum);
            if (!int.TryParse(Console.ReadLine(), out int dayNum) || dayNum < 1 || dayNum > maxDayNum)
            {
                Console.WriteLine("Day number out of range.");
                return;
            }

            var (month, day) = GetMonthAndDay(dayNum, isLeapYear);
            Console.WriteLine("{0} {1}", day, MonthNames[month]);
        }

        static (int month, int day) GetMonthAndDay(int dayNum, bool isLeapYear)
        {
            int[] daysInMonth = isLeapYear ? DaysInLeapMonths : DaysInMonths;
            int monthNum = 0;

            foreach (int days in daysInMonth)
            {
                if (dayNum <= days)
                {
                    break;
                }
                dayNum -= days;
                monthNum++;
            }

            return (monthNum, dayNum);
        }

        static readonly string[] MonthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        static readonly int[] DaysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static readonly int[] DaysInLeapMonths = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    }
}
