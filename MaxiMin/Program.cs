using System;
using System.Text;


namespace MaxiMin
{
    class Program
    {
        static void Main(string[] args)
        {
            var massiv = UniqueRandomArray(-100, 100, 10);
            int Min = massiv[0];
            int Max = massiv[9];
            int Mandex = 0;
            int Mindex = 0;
            for (int i = 0; i < massiv.Length-1; i++)
            {
                if (massiv[i + 1] < Min)
                {
                    Min = massiv[i + 1];
                    Mindex = i + 1;
                }

                if (massiv[i + 1] > Max)
                {
                    Max = massiv[i + 1];
                    Mandex = i + 1;
                }

            }

            ArrayToString(massiv);
            Console.WriteLine(Min);
            Console.WriteLine(Max);

            int x = massiv[Mindex];
            int y = massiv[Mandex];
            int z = x;
            x = y;
            y = z;
            massiv[Mindex] = x;
            massiv[Mandex] = y;

            ArrayToString(massiv);
        }
        static bool ArrayContains(int[] numbers, int number)
        {
            foreach (var num in numbers) if (number == num) return true;
            return false;
        }
        static int[] UniqueRandomArray(int min, int max, int length, Random? random = null)
        {
            if (min >= max) throw new ArgumentException("Не верно задан диапазон - min >= max");
            if ((max - min) <= length) throw new ArgumentException("Диапазон не позволяет");

            random = random ?? new Random(DateTime.Now.Millisecond);
            var result = new int[length];
            var zeroFirst = true;
            for (var i = 0; i < length; i++)
            {
                var res = 0;
                do
                {
                    res = random.Next(min, max);
                    if (res == 0)
                    {
                        if (zeroFirst)
                        {
                            zeroFirst = false;
                            break;
                        }
                        continue;
                    }
                } while (ArrayContains(result, res));
                result[i] = res;
            }
            return result;
        }

        static string ArrayToString(int[] numbers, bool show = true)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in numbers) sb.Append(item).Append(' ');
            var result = sb.ToString().TrimEnd(' ');
            if (show) Console.WriteLine(result);
            return result;
        }
    }

}
