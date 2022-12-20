using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<(int, int)> box = new List<(int, int)> { (3, 1), (4, 5), (2, 4) };
            (int, int) hero = (3, 3);
            char[,] playingField =
            {
                {'#','#','#','#','#','#','#'},
                {'#','#','#',' ',' ','#','#'},
                {'#','.',' ',' ',' ',' ','#'},
                {'#',' ','.',' ',' ',' ','#'},
                {'#','#',' ',' ','.',' ','#'},
                {'#',' ','.',' ',' ',' ','#'},
                {'#',' ',' ','#',' ',' ','#'},
                {'#','#','#','#','#','#','#'},
            };
            PrintField(playingField,hero/*, box*/);
            while (true)
            {
                movementFigure(playingField,ref hero/*, ref box*/);
            }
        }
        static void movementFigure(char[,] playingField, ref (int, int) index/*, ref List<(int, int)> box*/)
        {
            var key = Console.ReadKey().Key;

            (int, int) way = (0, 0);
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    way = (0, -1);
                    break;

                case ConsoleKey.RightArrow:
                    way = (0, 1);
                    break;

                case ConsoleKey.UpArrow:
                    way = (-1, 0);
                    break;

                case ConsoleKey.DownArrow:
                    way = (1, 0);
                    break;
            }

            if (way.Item1 == 0 & way.Item2 == 0)
            {
                return;
            }

            if (playingField[index.Item1 + way.Item1, index.Item2 + way.Item2] == '#'
                || playingField[index.Item1 + way.Item1, index.Item2 + way.Item2] == '&')
            {
                return;
            }
            else
            {
                index = (index.Item1 + way.Item1, index.Item2 + way.Item2);
            }

            Console.Clear();
            PrintField(playingField, index/*,box*/);

        }
        static void PrintField(char[,] playingField, (int, int) index/*, List<(int, int)> box*/)
       {
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    if (i == index.Item1 && j == index.Item2)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write("$ ");
                    }
                    //else if (i == box[i].Item1 && j == box[i].Item2)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Black;
                    //    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    //    Console.Write("& ");
                    //}
                    else if (playingField[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(playingField[i, j] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write(playingField[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
       }
    }
}
