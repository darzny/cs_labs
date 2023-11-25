using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArrayHandling
{
    class Program
    {
        static void Main()
        {
            int size = InputSize();

            if (size != 0)
            {
                int[] array = new int[size];
                FillArrayFromConsole(array);

                PtintResults(array);
            }
        }

        static int InputSize()
        {
            Console.Write("Введите размер массива: ");
            if (!int.TryParse(Console.ReadLine(), out int size))
            {
                Console.WriteLine("Невалидное значение!");
                return 0;
            }

            return size;
        }

        static void PtintResults(int[] array)
        {
            Console.WriteLine($"Сумма всех элементов массива: {CalculateSum(array)}");
            Console.WriteLine($"Среднее значение массива: {CalculateAverage(array)}");
            Console.WriteLine($"Сумма отрицательных элементов: {CalculateNegativeSum(array)}");
            Console.WriteLine($"Сумма положительных элементов: {CalculatePositiveSum(array)}");

            int[] oddAndEvenSums = CalculateOddAndEvenElementsSum(array);

            Console.WriteLine($"Сумма нечетных элементов: {oddAndEvenSums[0]}");
            Console.WriteLine($"Сумма четных элементов: {oddAndEvenSums[1]}");

            int maxIndex, minIndex;
            int maxValue = FindMaxValue(array, out maxIndex);
            int minValue = FindMinValue(array, out minIndex);

            Console.WriteLine($"Максимальный элемент: {maxValue}, Индекс: {maxIndex}");
            Console.WriteLine($"Минимальный элемент: {minValue}, Индекс: {minIndex}");

            Console.WriteLine($"Произведение элементов между мин и макс элементами: {CalculateMultiplicationResultBetweenMinAndMax(array, minIndex, maxIndex)}");
        }

        static void FillArrayFromConsole(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Введите элемент {i + 1}: ");

                if (!int.TryParse(Console.ReadLine(), out int res))
                {
                    Console.WriteLine("Невалидное значение! Заменено на 0");
                    arr[i] = 0;
                    return;
                }
                arr[i] = res;
            }
        }

        static int CalculateSum(int[] arr)
        {
            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }

        static double CalculateAverage(int[] arr)
        {
            int sum = CalculateSum(arr);
            return (double)sum / arr.Length;
        }

        static int CalculateNegativeSum(int[] arr)
        {
            int negativeSum = 0;
            foreach (int num in arr)
            {
                if (num < 0) negativeSum += num;
            }
            return negativeSum;
        }

        static int CalculatePositiveSum(int[] arr)
        {
            int positiveSum = 0;
            foreach (int num in arr)
            {
                if (num > 0) positiveSum += num;
            }
            return positiveSum;
        }

        static int[] CalculateOddAndEvenElementsSum(int[] arr)
        {
            int oddSum = 0;
            int evenSum = 0;
            int index = 1;

            foreach (int num in arr)
            {
                if (index % 2 == 0) evenSum += num;
                else oddSum += num;

                index++;
            }

            int[] result = new int[2];
            result[0] = oddSum;
            result[1] = evenSum;

            return result;
        }

        static int FindMaxValue(int[] arr, out int maxIndex)
        {
            int maxValue = arr[0];
            maxIndex = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                    maxIndex = i;
                }
            }

            return maxValue;
        }

        static int FindMinValue(int[] arr, out int minIndex)
        {
            int minValue = arr[0];
            minIndex = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                    minIndex = i;
                }
            }

            return minValue;
        }

        static int CalculateMultiplicationResultBetweenMinAndMax(int[] arr, int minIndex, int maxIndex)
        {
            int result = 0;

            int start = Math.Min(maxIndex, minIndex) + 1;
            int end = Math.Max(maxIndex, minIndex);

            if (end - start != 1)
            {
                result = 1;

                for (int i = start; i < end; i++)
                {
                    result *= arr[i];
                };
            }

            return result;
        }
    }
}