using System;

namespace Matrix
{
    class MatrixMultiply
    {
        static void Output(int[,] result)
        {
            for (int r = 0; r < result.GetLength(0); r++)
            {
                for (int c = 0; c < result.GetLength(1); c++)
                {
                    Console.Write("{0} ", result[r, c]);
                }
                Console.WriteLine();
            }
        }

        static int[,] Multiply(int[,] a, int[,] b)
        {
            int[,] result = new int[2, 2];

            for (int r = 0; r < result.GetLength(0); r++)
            {
                for (int c = 0; c < result.GetLength(1); c++)
                {
                    result[r, c] += a[r, 0] * b[0, c] + a[r, 1] * b[1, c];
                }
            }
            return result;
        }

        static void Input(int[,] dst)
        {
            for (int r = 0; r < dst.GetLength(0); r++)
            {
                for (int c = 0; c < dst.GetLength(1); c++)
                {
                    Console.Write("Enter value for [{0},{1}] : ", r, c);
                    dst[r, c] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
        }

        static void Main3()
        {
            int[,] a = new int[2, 2];
            int[,] b = new int[2, 2];

            Console.WriteLine("Enter values for matrix A:");
            Input(a);

            Console.WriteLine("Enter values for matrix B:");
            Input(b);

            int[,] result = Multiply(a, b);

            Output(result);
        }
    }
}
