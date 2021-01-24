using System;
using System.Linq;

namespace Lesson_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа печати чисел, находящихся на главной диагонали матрицы, приветствует вас");
            var matrix = GenerateMatrix(0, 9);
            Console.WriteLine("Сгенерированная матрица:");
            PrintMatrix(matrix);
            Console.WriteLine($"Числа на главной диагонали: {GetMainDiagonalNumbers(matrix)}");
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            } 
        }

        private static string GetMainDiagonalNumbers(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1))
            {
                throw new ArgumentException("Invalid matrix size.");
            }
            int[] toReturn = new int[size];
            for (int i = 0; i < size; i++)
            {
                toReturn[i] = matrix[i, i];
            }
            return string.Join(' ', toReturn);
        }

        private static int[,] GenerateMatrix(int minValue, int maxValue)
        {
            int size = default;
            GetUserInput(ref size);
            int [,] matrix = new int[size,size];
            FillMatrixWitRandomNumber(matrix, minValue,maxValue);
            return matrix;
        }
        private static void GetUserInput(ref int matrixSize)
        {
            do
            {
                Console.WriteLine(
                    string.Concat("Введите положительное числовое значение размера матрицы.", Environment.NewLine, 
                        "Пример : значению 2 будет соотвествовать матрица 2х2"));
            } while (!Int32.TryParse(Console.ReadLine(), out matrixSize) || matrixSize <= 0);
        }

        private static void FillMatrixWitRandomNumber(int[,] matrix, int minValue, int maxValue)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = GetRandomNumber(minValue, maxValue, rand);
                }
            }
        }
        private static int GetRandomNumber(int minValue, int maxValue, Random rand) => rand.Next(minValue, maxValue + 1);
    }
}