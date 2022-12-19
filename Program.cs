using System;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] playingField =
            {
                {' ',' ','#','#','#','#',' '},
                {'#','#','#',' ',' ','#',' '},
                {'#','.',' ','$',' ','#',' '},
                {'#','&','.','#',' ','#',' '},
                {'#','#',' ',' ','.',' ','#'},
                {'#',' ','.','&',' ','#',' '},
                {'#','&',' ','#',' ','#',' '},
                {'#','#',' ','#',' ','#',' '},
            };
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    Console.Write(playingField[i,j] + " ");
                }
                Console.WriteLine();
            }
            while (true)
            {
                movementFigure(playingField);
            }
        }
        static void movementFigure(char[,] playingField)
        {
            (int, int) index = (0, 0);
            var key = Console.ReadKey().Key;
            Console.Clear();
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    if (playingField[i, j] == '$')
                    {
                        index.Item1 = i;
                        index.Item2 = j;
                    }
                    else { continue; }
                }
            }
            (int, int) way = (0,0);
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

            if(way.Item1 == 0 & way.Item2 == 0)
            {
                return;
            }

            playingField[index.Item1, index.Item2] = ' ';
            if (playingField[index.Item1 + way.Item1, index.Item2 + way.Item2] == '#')
            {
                playingField[index.Item1, index.Item2] = '$';
            }
            else
            {
                playingField[index.Item1 + way.Item1, index.Item2 + way.Item2] = '$';
            }

            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    Console.Write(playingField[i, j] + " ");
                }
                Console.WriteLine();
            }
                //return playingField;
        }
        //public static (int, int) GetCoordinatesToMove(ConsoleKey key)
        //{
        //    switch (key)
        //    {
        //        case ConsoleKey.LeftArrow:
        //            return (1, 0);
        //        case ConsoleKey.UpArrow:
        //            return (0, 1);
        //        case ConsoleKey.RightArrow:
        //            return (1, 0);
        //        case ConsoleKey.DownArrow:
        //            return (0, 1);



        //        default:
        //            return (99,99);
        //    }
        //    playingField[index.Item1, index.Item2] = ' ';
        //    if (playingField[index.Item1, index.Item2 + 1] == '#')
        //    {
        //        Console.WriteLine("Немає можливості сюди пройти ¯\\_(ツ)_/¯");
        //        playingField[index.Item1, index.Item2] = '$';
        //    }
        //    else
        //    {
        //        playingField[index.Item1, index.Item2 + 1] = '$';
        //    }
        //}
    }
}
