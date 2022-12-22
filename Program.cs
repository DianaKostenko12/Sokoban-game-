using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] playingField =
           {
                {'#','#','#','#','#','#','#'},
                {'#','#','#',' ',' ','#','#'},
                {'#',' ',' ',' ',' ',' ','#'},
                {'#',' ','.',' ',' ',' ','#'},
                {'#','#',' ',' ','.',' ','#'},
                {'#',' ','.',' ',' ',' ','#'},
                {'#',' ',' ','#',' ',' ','#'},
                {'#','#','#','#','#','#','#'},
            };
            List<(int, int)> indexOfDot = ListDot(playingField);
            (int, int) way = (0, 0);
            List<(int, int)> box = new List<(int, int)> { (3, 1), (4, 5), (2, 4) };
            (int, int) hero = (3, 3);
           
            PrintField(playingField, hero, box,way,indexOfDot);
            while (true)
            {
                movementFigure(playingField, ref hero, ref box, indexOfDot);
            }
        }
        static void movementFigure(char[,] playingField, ref (int, int) index, ref List<(int, int)> box, List<(int, int)> indexOfDot)
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

            if (playingField[index.Item1 + way.Item1, index.Item2 + way.Item2] == '#')
            {
                return;
            }
            else if(BoxList(box, index.Item1 + way.Item1, index.Item2 + way.Item2))
            {
                if(playingField[index.Item1 + way.Item1+ way.Item1, index.Item2 + way.Item2+ way.Item2] == '#')
                {
                    return;
                }
                else
                {
                    index = (index.Item1 + way.Item1, index.Item2 + way.Item2);
                    var boxindex = IndexofTuple(box, index);
                    box[boxindex] = (box[boxindex].Item1 + way.Item1,
                        box[boxindex].Item2 + way.Item2);
                }
            }
            else
            {
                index = (index.Item1 + way.Item1, index.Item2 + way.Item2);
            }

            Console.Clear();
            PrintField(playingField, index, box,way,indexOfDot);

        }
        static void PrintField(char[,] playingField, (int, int) index, List<(int, int)> boxs, (int, int) way, List<(int, int)> indexOfDot)
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
                    else if (BoxList(boxs, i, j))
                    {
                        if(ColourOfBox((i, j), indexOfDot))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }

                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write("& ");
                    }
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
        static bool BoxList(List<(int, int)> box, int i, int j)
        {
            for (int k = 0; k < box.Count; k++)
            {
                if (box[k].Item1 == i && box[k].Item2 == j)
                {
                    return true;
                }
            }
            return false;
        }
        static int IndexofTuple(List<(int, int)> box, (int, int) index)
        {
            for (int k = 0; k < box.Count; k++)
            {
                if (index.Item1 == box[k].Item1 && index.Item2 == box[k].Item2)
                {
                    return k;
                }
            }
            return 0;
        }
        static bool ColourOfBox((int, int) box, List<(int, int)> indexOfDot)
        {
            for (int i = 0; i < indexOfDot.Count; i++)
            {
                if (box.Item1 == indexOfDot[i].Item1 && box.Item2 == indexOfDot[i].Item2)
                {
                    return true;
                }
            }

            return false;
        }
        static List<(int, int)> ListDot(char[,] playingField)
        {
            var list = new List<(int, int)>();
            for (int i = 0; i < playingField.GetLength(0); i++)
            {
                for (int j = 0; j < playingField.GetLength(1); j++)
                {
                    if (playingField[i, j] == '.')
                    {
                        list.Add((i, j));
                    }
                }
            }

            return list;
        }
    }
}
