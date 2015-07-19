using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

class TargetPractice
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[] matrixDem = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        char[,] target = new char[matrixDem[0], matrixDem[1]];
        char[] snake = Console.ReadLine().ToCharArray();
        FillMatrix(target, snake);
        int[] shot = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        for (int i = 0; i < target.GetLength(0); i++)
        {
            for (int j = 0; j < target.GetLength(1); j++)
            {
                if (IsInRadius(i, j, shot[0], shot[1], shot[2]))
                {
                    target[i, j] = ' ';
                }
            }
        }
        for (int j = 0; j < target.GetLength(1); j++)
        {
            for (int i = target.GetLength(0) - 1; i > 0; i--)
            {
                if (target[i, j] == ' ')
                {
                    int k;
                    for (k = i - 1; k > 0; k--)
                    {
                        if (target[k, j] != ' ')
                        {
                            break;
                        }
                    }
                    target[i, j] = target[k, j];
                    target[k, j] = ' ';
                }
            }
        }
        PrintMatrix(target);
    }

    private static bool IsInRadius(int x, int y, int xCenter, int yCenter, int r)
    {
        if (((x - xCenter) * (x - xCenter) + (y - yCenter) * (y - yCenter)) <= r * r)
        {
            return true;
        }
        return false;
    }

    private static void FillMatrix(char[,] matrix, char[] snake)
    {
        int filler = 0;
        bool reverse = true;
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            if (reverse)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    matrix[i, j] = snake[filler % snake.Length];
                    filler++;
                }
                reverse = false;
            }
            else
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = snake[filler % snake.Length];
                    filler++;
                }
                reverse = true;
            }
        }
    }
    private static void PrintMatrix(char[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            StringBuilder line = new StringBuilder();
            for (int j = 0; j < array.GetLength(1); j++)
            {
                line.Append(array[i, j]);
            }
            Console.WriteLine(line.ToString());
        }
    }
}
