using System;

namespace TargetShooting
{
    class TargetShooting
    {
        static void Main(string[] args)
        {
            const string end = "end";
            const int targetSize = 5;

            int totalScore = 0;
            string input;

            List<Shot> shots = new List<Shot>();

            Target target = new Target(targetSize);

            Console.WriteLine($"Вводите координаты выстрелов. Для завершения введите {end}.");

            while (true)
            {
                Console.Write("Введите координаты выстрела (x y) через пробел: ");

                input = Console.ReadLine();

                if (input.ToLower() == end)
                {
                    break;
                }

                totalScore = HandleShot(input, target, totalScore, shots);
            }

            PrintResults(totalScore, shots, target);
        }

        private static Random random = new Random();

        struct Shot
        {
            public double XCoord;
            public double YCoord;

            public Shot(double x, double y)
            {
                XCoord = x;
                YCoord = y;
            }

            public void PrintShot()
            {
                Console.WriteLine($"X: {XCoord}, Y: {YCoord}");
            }
        }

        struct Target
        {
            public double X;
            public double Y;

            public Target(int size)
            {
               X = Math.Floor(random.NextSingle() * 10 - size);
               Y = Math.Floor(random.NextSingle() * 10 - size);
            }

            public int CalculateScore(Shot shot)
            {
                double distance = Math.Sqrt((shot.XCoord - X) * (shot.XCoord - X) + (shot.YCoord - Y) * (shot.YCoord - Y));

                if (distance <= 1) return 10;
                if (distance <= 2) return 5;
                if (distance <= 3) return 1;
                return 0;
            }

            public void PrintCenter()
            {
                Console.WriteLine($"Центр мишени: {X}, {Y}");
            }
        }

        private static void PrintResults(int totalScore, List<Shot> shots, Target target)
        {
            Console.WriteLine($"Итоговый результат: {totalScore}");
            target.PrintCenter();
            Console.WriteLine("Все выстрелы:");
            shots.ForEach(shot => shot.PrintShot());
        }

        private static int HandleShot(string input, Target target, int totalScore, List<Shot> shots)
        {
            if (input == "")
            {
                Console.WriteLine("Пустой ввод. Попробуйте ещё раз.");
                return totalScore;
            }

            string[] parts = input.Split(' ');

            if (parts.Length != 2
                || !double.TryParse(parts[0], out double x)
                || !double.TryParse(parts[1], out double y))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
                return totalScore;
            }

            Shot shot = new Shot(x, y);
            int score = target.CalculateScore(shot);

            totalScore += score;
            shots.Add(shot);

            Console.WriteLine($"Промежуточный результат {score}({totalScore}).");

            return totalScore;
        }
    }
}
