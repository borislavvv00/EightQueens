using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EighthQueens
{
    partial class Map
    {
        private const int cellsNumber = 8;
        private char[,] field = new char[cellsNumber, cellsNumber];

        private void Write<T>(T n, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"{n}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void FieldSetUp()
        {
            //Full the field with spaces.
            for (int i = 0; i < cellsNumber; i++)
            {
                for (int j = 0; j < cellsNumber; j++)
                {
                    field[i, j] = ' ';
                }
            }
        }

        public void PlaceQueen(int x, int y)
        {
            /* Q - sign for queen
               # - positions where queen can move*/
            for (int i = 0; i < cellsNumber; i++)
            {
                for (int j = 0; j < cellsNumber; j++)
                {
                    if (x == i && j == y)
                    {
                        field[i, j] = 'Q';

                        int k = x + 1;
                        while (k < cellsNumber)
                        {
                            field[k, j] = '#';
                            k++;
                        }//down

                        k = 0;
                        while (k < x)
                        {
                            field[k, j] = '#';
                            k++;
                        }//up

                        k = y + 1;
                        while (k < cellsNumber)
                        {
                            field[i, k] = '#';
                            k++;
                        }//rigth

                        k = 0;
                        while (k < y)
                        {
                            field[i, k] = '#';
                            k++;
                        }//left

                        k = 1;
                        while (i - k >= 0 && j - k >= 0)
                        {
                            field[i - k, j - k] = '#';
                            k++;
                        }//upLeft diagonal

                        k = 1;
                        while (i + k < cellsNumber && j + k < cellsNumber)
                        {
                            field[i + k, j + k] = '#';
                            k++;
                        }//downLeft diagonal

                        k = 1;
                        while (i - k >= 0 && j + k < cellsNumber)
                        {
                            field[i - k, j + k] = '#';
                            k++;
                        }//upRigth diagonal

                        k = 1;
                        while (i + k < cellsNumber && j - k >= 0)
                        {
                            field[i + k, j - k] = '#';
                            k++;
                        }//downRigth diagonal
                    }
                }
            }
        }

        public void DrawField()
        {
            Console.Write(" ");
            for (int i = 0; i < cellsNumber; i++)
            {
                Write(i, ConsoleColor.Green);
            }
            Console.WriteLine();

            for (int i = 0; i < cellsNumber; i++)
            {
                for (int j = 0; j < cellsNumber; j++)
                {
                    if (j == 0)
                    {
                        Write(i, ConsoleColor.Green);
                    }

                    if (field[i, j] == '#')
                    {
                        Write(field[i, j], ConsoleColor.White);
                    }
                    else if (field[i, j] == 'Q')
                    {
                        Write(field[i, j], ConsoleColor.Red);
                    }
                    else
                    {
                        Console.Write($"{field[i, j]}");
                    }
                }
                Console.WriteLine();
            }
        }
        
        static void Main(string[] args)
        {
            Map map = new Map();

            int y = 0;
            int x = 0;
            while (true)
            {
                Console.WriteLine("Enter Y coordinate of the first queen : ");
                while (!int.TryParse(Console.ReadLine(), out y))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                }

                Console.WriteLine("Enter X coordinate of the first queen : ");
                while (!int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                }

                map.FieldSetUp();
                map.PlaceQueen(x, y);
                map.CheckSells(x, y);
                map.DrawField();
            }
        }
    }
}
