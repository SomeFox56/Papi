﻿using CSharpStudy;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            GameData[,] gameField = new GameData[3, 3];

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    gameField[i, j] = new GameData();
                    if (gameField[i, j].CellValue == 0)
                        gameField[i, j].CellSymbol = " * ";                   
                                              
                }

            }

            bool endGame = false;
            bool firstGamer = true;

            int summHorizontal = 0;
            int summVertical = 0;
            int summDiagonalMain = 0;


            while (!endGame)
            {
                int choiseX = int.Parse(Console.ReadLine());
                int choiseY = int.Parse(Console.ReadLine());

                if (gameField[choiseX - 1, choiseY - 1].CellValue != 0)
                {
                    Console.WriteLine("cell is unaccesible");
                }
                else
                {
                    if (firstGamer)
                    {
                        gameField[choiseX - 1, choiseY - 1].CellSymbol = " X ";
                        gameField[choiseX - 1, choiseY - 1].CellValue = 1;
                        firstGamer = !firstGamer;
                    }
                    else
                    {
                        gameField[choiseX - 1, choiseY - 1].CellSymbol = " O ";
                        gameField[choiseX - 1, choiseY - 1].CellValue = 4;
                        firstGamer = !firstGamer;
                    }

                }



                for (int i = 0; i < gameField.GetLength(0); i++)
                {
                    for (int j = 0; j < gameField.GetLength(1); j++)
                    {
                        Console.Write(gameField[i, j].CellSymbol);
                    }
                    Console.WriteLine();
                }



                for (int i = 0; i < gameField.GetLength(0); i++)
                {
                    for (int j = 0; j < gameField.GetLength(1); j++)
                    {
                        summHorizontal += gameField[i, j].CellValue;
                        summVertical += gameField[j, i].CellValue;
                    }
                    if (summHorizontal == 3 || summVertical == 3 || summDiagonalMain == 3)
                    {
                        Console.WriteLine("First mint");
                        endGame = true;
                    }
                    if (summHorizontal == 12 || summVertical == 12 || summDiagonalMain == 12)
                    {
                        Console.WriteLine("Second vinner");
                        endGame = true;
                    }
                    summHorizontal = 0;
                    summVertical = 0;
                    summDiagonalMain += gameField[i, i].CellValue;
                }


            }
            Console.WriteLine("game over");

        }
    }
}