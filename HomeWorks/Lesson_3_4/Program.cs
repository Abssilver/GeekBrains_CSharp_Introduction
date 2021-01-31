using System;

namespace Lesson_3_4
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Программа вывода на экран игрового поля игры \"Морской бой\" приветствует вас");
            char [,] gameField = new char[10, 10];
            GenerateMap(gameField);
            DrawCircles(gameField);
            Console.WriteLine("Сгенерированное поле:");
            PrintField(gameField);
            Console.WriteLine("Нажмите любую клавишу для завершения программы");
            Console.ReadKey();
        }

        private static void GenerateMap(char[,] gameField)
        {
            int[] ships = {4, 3, 3, 2, 2, 2, 1, 1, 1, 1};
            bool success = false;
            ClearField(gameField);
            for (int i = 0; i < ships.Length; i++)
            {
                SetupShip(gameField, ships[i], out success);
                if (!success)
                {
                    break;
                }
            }
            if (!success)
            {
                GenerateMap(gameField);
            }
        }
        private static void SetupShip(char[,] gameField, int shipLength, out bool success)
        {
            bool vertical, horizontal;
            if (IsAvailableToPlace(gameField, shipLength, out horizontal, out vertical))
            {
                if (horizontal && vertical)
                {
                    //go horizonrtal
                    if (GetRandomDirection() < 1)
                    {
                        PlaceHorizontal(gameField, shipLength);
                    }
                    //go vertical
                    else
                    {
                        PlaceVertical(gameField, shipLength);
                    }
                    //draw circles
                    DrawCirclesNearShips(gameField);
                }
                success = true;
            }
            else
            {
                success = false;
            }
        }

        private static void DrawCirclesNearShips(char[,] gameField)
        {
            bool up, down, left, right;
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    up = down = left = right = false;
                    if (gameField[i, j] == 'X')
                    {
                        if (i-1 >= 0 && gameField[i - 1, j] != 'X')
                        {
                            gameField[i - 1, j] = 'O';
                            left = true;
                        }
                        if (i+1 < gameField.GetLength(0) && gameField[i + 1, j] != 'X')
                        {
                            gameField[i + 1, j] = 'O';
                            right = true;
                        }
                        if (j-1 >= 0 && gameField[i, j-1] != 'X')
                        {
                            gameField[i, j-1] = 'O';
                            up = true;
                        }
                        if (j+1 < gameField.GetLength(1) && gameField[i, j+1] != 'X')
                        {
                            gameField[i, j+1] = 'O';
                            down = true;
                        }
                        if (up&&left)
                        {
                            gameField[i-1, j-1] = 'O';
                        }
                        if (up&&right)
                        {
                            gameField[i+1, j-1] = 'O';
                        }
                        if (down&&left)
                        {
                            gameField[i-1, j+1] = 'O';
                        }
                        if (down&&right)
                        {
                            gameField[i+1, j+1] = 'O';
                        }
                    }
                }
            }
        }

        private static void DrawCircles(char[,] gameField)
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == 'e')
                    {
                        gameField[i, j] = 'O';
                    }
                }
            }
        }
        private static void PrintField(char[,] gameField)
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    Console.Write($"{gameField[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        private static void PlaceHorizontal(char[,] gameField, int shipLength)
        {
            bool shipPlaced = false;
            //go down
            if (GetRandomDirection() < 1)
            {
                //go right
                if (GetRandomDirection() < 1)
                {
                    int counter;
                    for (int i = 0; i < gameField.GetLength(0); i++)
                    {
                        counter = 0;
                        for (int j = 0; j < gameField.GetLength(1); j++)
                        {
                            if (gameField[i, j] == 'e')
                            {
                                counter++;
                                if (counter > 1 && gameField[i, j - 1]!= 'e')
                                {
                                    counter = 1;
                                }
                                if (counter == shipLength)
                                {
                                    for (int k = shipLength; k > 0; k--)
                                    {
                                        gameField[i, j - k + 1] = 'X';
                                    }
                                    shipPlaced = true;
                                    break;
                                }
                            }
                        }
                        if (shipPlaced)
                        {
                            break;
                        }
                    }
                }
                //go left
                else
                {
                    int counter;
                    for (int i = 0; i < gameField.GetLength(0); i++)
                    {
                        counter = 0;
                        for (int j = gameField.GetLength(1) - 1; j >=0; j--)
                        {
                            if (gameField[i, j] == 'e')
                            {
                                counter++;
                                if (counter > 1 && gameField[i, j + 1]!= 'e')
                                {
                                    counter = 1;
                                }
                                if (counter == shipLength)
                                {
                                    for (int k = shipLength; k > 0; k--)
                                    {
                                        gameField[i, j + k - 1] = 'X';
                                    }
                                    shipPlaced = true;
                                    break;
                                }
                            }
                        }
                        if (shipPlaced)
                        {
                            break;
                        }
                    }
                }
            }
            //go up
            else
            {
                //go right
                if (GetRandomDirection() < 1)
                {
                    int counter;
                    for (int i = gameField.GetLength(0) - 1; i >= 0 ; i--)
                    {
                        counter = 0;
                        for (int j = 0; j < gameField.GetLength(1); j++)
                        {
                            if (gameField[i, j] == 'e')
                            {
                                counter++;
                                if (counter > 1 && gameField[i, j - 1]!= 'e')
                                {
                                    counter = 1;
                                }
                                if (counter == shipLength)
                                {
                                    for (int k = shipLength; k > 0; k--)
                                    {
                                        gameField[i, j - k + 1] = 'X';
                                    }
                                    shipPlaced = true;
                                    break;
                                }
                            }
                        }
                        if (shipPlaced)
                        {
                            break;
                        }
                    }
                }
                //go left
                else
                {
                    int counter;
                    for (int i = gameField.GetLength(0) - 1; i >= 0 ; i--)
                    {
                        counter = 0;
                        for (int j = gameField.GetLength(1) - 1; j >=0; j--)
                        {
                            if (gameField[i, j] == 'e')
                            {
                                counter++;
                                if (counter > 1 && gameField[i, j + 1]!= 'e')
                                {
                                    counter = 1;
                                }
                                if (counter == shipLength)
                                {
                                    for (int k = shipLength; k > 0; k--)
                                    {
                                        gameField[i, j + k - 1] = 'X';
                                    }
                                    shipPlaced = true;
                                    break;
                                }
                            }
                        }
                        if (shipPlaced)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static void PlaceVertical(char[,] gameField, int shipLength)
        {
            bool shipPlaced = false;
            //go down
            if (GetRandomDirection() < 1)
            {
                //go right
                if (GetRandomDirection() < 1)
                {
                    int counter;
                    for (int i = 0; i < gameField.GetLength(1); i++)
                    {
                        counter = 0;
                        for (int j = 0; j < gameField.GetLength(0); j++)
                        {
                            if (gameField[j, i] == 'e')
                            {
                                counter++;
                                if (counter > 1 && gameField[j - 1, i]!= 'e')
                                {
                                    counter = 1;
                                }
                                if (counter == shipLength)
                                {
                                    for (int k = shipLength; k > 0; k--)
                                    {
                                        gameField[j - k + 1, i] = 'X';
                                    }
                                    shipPlaced = true;
                                    break;
                                }
                            }
                        }
                        if (shipPlaced)
                        {
                            break;
                        }
                    }
                }
                //go left
                else
                {
                    int counter;
                    for (int i = gameField.GetLength(1) - 1; i >=0 ; i--)
                    {
                        counter = 0;
                        for (int j = 0; j < gameField.GetLength(0); j++)
                        {
                            if (gameField[j, i] == 'e')
                            {
                                counter++;
                                if (counter > 1 && gameField[j - 1, i]!= 'e')
                                {
                                    counter = 1;
                                }
                                if (counter == shipLength)
                                {
                                    for (int k = shipLength; k > 0; k--)
                                    {
                                        gameField[j - k + 1, i] = 'X';
                                    }
                                    shipPlaced = true;
                                    break;
                                }
                            }
                        }
                        if (shipPlaced)
                        {
                            break;
                        }
                    }
                }
            }
            //go up
            else
            {
                //go right
                if (GetRandomDirection() < 1)
                {
                    int counter;
                    for (int i = 0; i < gameField.GetLength(1); i++)
                    {
                        counter = 0;
                        for (int j = gameField.GetLength(0) - 1; j >= 0; j--)
                        {
                            if (gameField[j, i] == 'e')
                            {
                                counter++;
                                if (counter > 1 && gameField[j + 1, i]!= 'e')
                                {
                                    counter = 1;
                                }
                                if (counter == shipLength)
                                {
                                    for (int k = shipLength; k > 0; k--)
                                    {
                                        gameField[j + k - 1, i] = 'X';
                                    }
                                    shipPlaced = true;
                                    break;
                                }
                            }
                        }
                        if (shipPlaced)
                        {
                            break;
                        }
                    }
                }
                //go left
                else
                {
                    int counter;
                    for (int i = gameField.GetLength(1) - 1; i >= 0 ; i--)
                    {
                        counter = 0;
                        for (int j = gameField.GetLength(0) - 1; j >=0; j--)
                        {
                            if (gameField[j, i] == 'e')
                            {
                                counter++;
                                if (counter > 1 && gameField[j + 1, i]!= 'e')
                                {
                                    counter = 1;
                                }
                                if (counter == shipLength)
                                {
                                    for (int k = shipLength; k > 0; k--)
                                    {
                                        gameField[j + k - 1, i] = 'X';
                                    }
                                    shipPlaced = true;
                                    break;
                                }
                            }
                        }
                        if (shipPlaced)
                        {
                            break;
                        }
                    }
                }
            }
        }
        private static int GetRandomDirection() => rnd.Next(0, 2);

        private static bool IsAvailableToPlace(char[,] gameField, int shipLength, out bool horizontal, out bool vertical)
        {
            int counter;
            horizontal = vertical = false;
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                counter = 0;
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == 'e')
                    {
                        counter++;
                        if (counter > 1 && gameField[i, j - 1] != 'e')
                        {
                            counter = 1;
                        }
                    }
                }
                if (counter >= shipLength)
                {
                    horizontal = true;
                    break;
                }
            }
            for (int i = 0; i < gameField.GetLength(1); i++)
            {
                counter = 0;
                for (int j = 0; j < gameField.GetLength(0); j++)
                {
                    if (gameField[j, i] == 'e')
                    {
                        counter++;
                        if (counter > 1 && gameField[j - 1, i] != 'e')
                        {
                            counter = 1;
                        }
                    }
                }
                if (counter >= shipLength)
                {
                    vertical = true;
                    break;
                }
            }
            return horizontal || vertical;
        }

        private static void ClearField(char[,] gameField)
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    //set every element empty
                    gameField[i, j] = 'e';
                }
            }
        }
    }
}