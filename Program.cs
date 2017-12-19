
// Created by Grigoli Vashakidze
// Red ID: 819 818 812
// San Diego State University
// CompE 361
//
// 
// Visual studio community on macOS 
// 
// Description: This is a game called Tic-Tac-Toe with implemented AI that allows user to play agains the machine. This program checks directory if there is file game.txt then plays with it.
// If there is not game.txt it displays menu where user chooses 1 for human vs AI game
// and 2 for human vs human game.
//
//


using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Tic
{
    /// <summary>
    /// Program.
    /// </summary>
	class Program
    {
        static string[] Pos = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        static void Main(string[] args)
        {


            if (System.IO.File.Exists(@"game.txt"))
            {

                Console.WriteLine("File found play vs AI");
                PlayFileHelper();

            }
            else
            {

                Console.WriteLine("Enter 1 to play human vs AI \nEnter 2 to play human vs human");
                string x = Console.ReadLine();
                if (x == "1")
                {
                    Console.WriteLine("Human vs AI");
                    PrintPos();
                    Play();
                }
                else if (x == "2")
                {
                    Console.WriteLine("Human vs Human");
                    PrintPos();
                    PlayHuman();
                }
                else
                {
                    Console.WriteLine("Error input");
                }


            }
        }
        /// <summary>
        /// Play this instance.
        /// </summary>
		static void Play()
        {
            string json = JsonConvert.SerializeObject(Pos);
            Console.WriteLine("Enter position:");
            char[] positions = Console.ReadLine().ToCharArray();

            if (positions.Length != 2)
            {
                Console.WriteLine("Incorrect input");
                Play();
            }
            else
            {
                char xst = positions[0];
                int x;
                int y = int.Parse(positions[1].ToString());

                if (xst == 'A' || xst == 'a')
                {
                    Console.WriteLine("A");
                    x = 0;
                }
                else if (xst == 'B' || xst == 'b')
                {
                    Console.WriteLine("B");
                    x = 1;
                }
                else if (xst == 'C' || xst == 'c')
                {
                    x = 2;
                }
                else
                {
                    x = 3;
                }


                //validate user entry.
                if (!(CheckXandY(y) && CheckXandY(x)))
                {
                    Play();
                }

                int index = Ind(y, x);
                if (isFree(index))
                {
                    Pos[index] = "1";
                }
                else
                {
                    Play();
                }

                if (IfWon())
                {
                    PrintPos();
                    Console.WriteLine("You won the game");
                    File.WriteAllText(@"answer.json", json);
                    resetPos();
                }
                else
                {
                    DrawCheck();
                }
                AI();
                PrintPos();
                Play();
            }


        }

        /// <summary>
        /// Plaies the human.
        /// </summary>
        static void PlayHuman()
        {
            string json = JsonConvert.SerializeObject(Pos);
            Console.WriteLine("Enter position");
            char[] positions = Console.ReadLine().ToCharArray();

            if (positions.Length != 2)
            {
                Console.WriteLine("Incorrect input");
                PlayHuman();
            }
            else
            {
                char xst = positions[0];
                int x;
                int y = int.Parse(positions[1].ToString());

                if (xst == 'A' || xst == 'a')
                {
                    x = 0;
                }
                else if (xst == 'B' || xst == 'b')
                {
                    x = 1;
                }
                else if (xst == 'C' || xst == 'c')
                {
                    x = 2;
                }
                else
                {
                    x = 3;
                }


                //validate user entry.
                if (!(CheckXandY(y) && CheckXandY(x)))
                {
                    PlayHuman();
                }

                int index = Ind(y, x);
                if (isFree(index))
                {
                    Pos[index] = "1";
                }
                else
                {
                    PlayHuman();
                }

                if (IfWon())
                {
                    PrintPos();
                    Console.WriteLine("Player 1 won the game");
                    File.WriteAllText(@"answer.json", json);
                    resetPosSec();
                }
                else
                {
                    DrawCheck();
                }
                PrintPos();
                SecondHuman();
                PrintPos();
                PlayHuman();
            }


        }



        /// <summary>
        /// Seconds the human.
        /// </summary>
        static void SecondHuman()
        {
            string json = JsonConvert.SerializeObject(Pos);
            char[] positions = Console.ReadLine().ToCharArray();

            if (positions.Length != 2)
            {
                Console.WriteLine("Incorrect input");
                SecondHuman();
            }
            else
            {
                char xst = positions[0];
                int x;
                int y = int.Parse(positions[1].ToString());

                if (xst == 'A' || xst == 'a')
                {
                    x = 0;
                }
                else if (xst == 'B' || xst == 'b')
                {
                    x = 1;
                }
                else if (xst == 'C' || xst == 'c')
                {
                    x = 2;
                }
                else
                {
                    x = 3;
                }


                if (!(CheckXandY(y) && CheckXandY(x)))
                {
                    SecondHuman();
                }

                int index = Ind(y, x);
                if (isFree(index))
                {
                    Pos[index] = "2";
                }
                else
                {
                    SecondHuman();
                }

                if (IfWon())
                {
                    PrintPos();
                    Console.WriteLine("Player 2 won the game");
                    File.WriteAllText(@"answer.json", json);
                    resetPosSec();
                }
                else
                {
                    DrawCheck();
                }
                PrintPos();
                PlayHuman();
                PrintPos();
                SecondHuman();
            }

        }


        /// <summary>
        /// Player1 this instance.
        /// </summary>
        static void Player1()
        {

        }
        /// <summary>
        /// Player2 this instance.
        /// </summary>
		static void Player2()
        {

        }
        /// <summary>
        /// Player1 the specified x and y.
        /// </summary>
        /// <returns>The player1.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
		static void Player1(int x, int y)
        {
            string json = JsonConvert.SerializeObject(Pos);
            //validate user entry.
            if (!(CheckXandY(y) && CheckXandY(x)))
            {
                return;
            }



            int index = Ind(y, x);
            if (isFree(index))
            {
                Pos[index] = "1";
                PrintPos();
            }
            else
            {
                Player1();
            }

            if (IfWon())
            {
                Console.WriteLine("Player 1 won the game");
                File.WriteAllText(@"answer.json", json);
            }
            else
            {
                DrawCheck();
            }
        }



        /// <summary>
        /// Player2 the specified x and y.
        /// </summary>
        /// <returns>The player2.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        static void Player2(int x, int y)
        {
            string json = JsonConvert.SerializeObject(Pos);
            //validate user entry.
            if (!(CheckXandY(y) && CheckXandY(x)))
            {
                return;
            }

            int index = Ind(y, x);
            if (isFree(index))
            {
                Pos[index] = "2";
                PrintPos();
            }
            else
            {
                Player2();
            }

            if (IfWon())
            {
                Console.WriteLine("Player 2 won the game");
                File.WriteAllText(@"answer.json", json);
            }
            else
            {
                DrawCheck();
            }



        }

        /// <summary>
        /// Plaies the file helper.
        /// </summary>
        static void PlayFileHelper()
        {


            StreamReader file = new StreamReader("game.txt");
            var lineCount = File.ReadAllLines(@"game.txt").Length;
            for (int i = 0; i < lineCount; i++)
            {

                char[] game = File.ReadLines(@"game.txt").Skip(i).First().ToCharArray();
                String b = new String(game);

                if (b == "0000000000")
                {

                    Console.WriteLine("New game started !!!");
                    for (int j = 0; j <= 8; j++) Pos[j] = " ";


                }
                else if (IfWon() == false && DrawCheck() == false)
                {
                    char xst = game[4];
                    int x;

                    int y = int.Parse(game[5].ToString());

                    if (y > 2 || y < 0)
                    {

                        Console.WriteLine("Incorrect Input");

                    }
                    else
                    {

                        if (xst == 'A' || xst == 'a')
                        {
                            x = 0;
                        }
                        else if (xst == 'B' || xst == 'b')
                        {
                            x = 1;
                        }
                        else if (xst == 'C' || xst == 'c')
                        {
                            x = 2;
                        }
                        else
                        {
                            x = 3;
                        }



                        if (game[0] == 'P')
                        {
                            if (game[1] == '1')
                            {
                                Console.WriteLine();
                                Player1(x, y);

                            }
                            else if (game[1] == '2')
                            {
                                Console.WriteLine();
                                Player2(x, y);
                            }
                            else
                            {
                                Console.WriteLine("Input is incorrect");
                            }
                        }

                    }




                }
                else
                {



                }





            }
        }






        //AI
        /// <summary>
        /// Ai this instance.
        /// </summary>
		static void AI()
        {
            int[] free = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            int count = 0;
            int PosToWin = 0;
            for (int i = 0; i <= 8; i++)
            {
                if (Pos[i] == " ")
                {
                    free[count] = i;
                    count = count + 1;
                }
            }

            //check for winning move for computer
            PosToWin = WinMov("2", free);
            if (PosToWin != -1)
            {
                Pos[PosToWin] = "2";
            }
            else
            {
                //Find better position
                PosToWin = WinMov("1", free);
                if (PosToWin != -1)
                {
                    Pos[PosToWin] = "2";
                }
                else
                {
                    // if AI cant find winnig position then chooses randomli
                    Random Random = new Random();
                    int RndInt = Random.Next(0, count);
                    Pos[free[RndInt]] = "2";
                }
            }
            if (IfWon() == true)
            {
                PrintPos();
                Console.WriteLine("Game Over, You lost!");
                resetPos();
                Play();
            }
        }
        /// <summary>
        /// Windows the mov.
        /// </summary>
        /// <returns>The mov.</returns>
        /// <param name="playerMove">Player move.</param>
        /// <param name="openPositions">Open positions.</param>
		static int WinMov(string playerMove, int[] openPositions)
        {
            int maxAvailable = 0;
            // Need to figure out how high the open position array goes.
            for (int i = 0; i <= openPositions.Length - 1; i++)
            {
                if (openPositions[i] != -1) { maxAvailable = i; };
            }

            for (int i = 0; i <= maxAvailable; i++)
            {
                if (Pos[openPositions[i]] == " ")
                {
                    Pos[openPositions[i]] = playerMove;
                    if (IfWon() == true)
                    {
                        return (openPositions[i]);
                    }
                }
                Pos[openPositions[i]] = " ";
            }
            return -1;
        }
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns>The index.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
		static int Ind(int x, int y)
        {

            return x + y * 3;


        }
        /// <summary>
        /// Prints the position.
        /// </summary>
		static void PrintPos()
        {
            Console.WriteLine("  | 0 | 1 | 2 |");
            Console.WriteLine("  -------------");
            Console.WriteLine("A | {0} | {1} | {2} |", Pos[0], Pos[1], Pos[2]);
            Console.WriteLine("  --------------");
            Console.WriteLine("B | {0} | {1} | {2} |", Pos[3], Pos[4], Pos[5]);
            Console.WriteLine("  --------------");
            Console.WriteLine("C | {0} | {1} | {2} |", Pos[6], Pos[7], Pos[8]);
            Console.WriteLine("  --------------");
        }
        /// <summary>
        /// Checks the xand y.
        /// </summary>
        /// <returns><c>true</c>, if xand y was checked, <c>false</c> otherwise.</returns>
        /// <param name="z">The z coordinate.</param>
		static bool CheckXandY(int z)
        {
            if (z >= 0 && z < 3)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again");
                return false;
            }
        }
        /// <summary>
        /// Ises the free.
        /// </summary>
        /// <returns><c>true</c>, if free was ised, <c>false</c> otherwise.</returns>
        /// <param name="i">The index.</param>
		static bool isFree(int i)
        {

            if (Pos[i] == "1" || Pos[i] == "2")
            {
                Console.WriteLine("Invalid input. Try again");
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// Ifs the won.
        /// </summary>
        /// <returns><c>true</c>, if won was ifed, <c>false</c> otherwise.</returns>
		static bool IfWon()
        {
            if (
                (Pos[0] == Pos[1] && Pos[1] == Pos[2] && Pos[2] != " ") ||
                (Pos[3] == Pos[4] && Pos[4] == Pos[5] && Pos[5] != " ") ||
                (Pos[6] == Pos[7] && Pos[7] == Pos[8] && Pos[8] != " ") ||
                (Pos[0] == Pos[4] && Pos[4] == Pos[8] && Pos[8] != " ") ||
                (Pos[2] == Pos[4] && Pos[4] == Pos[6] && Pos[6] != " ") ||
                (Pos[0] == Pos[3] && Pos[3] == Pos[6] && Pos[6] != " ") ||
                (Pos[1] == Pos[4] && Pos[4] == Pos[7] && Pos[7] != " ") ||
                (Pos[2] == Pos[5] && Pos[5] == Pos[8] && Pos[8] != " ")
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Draws the check.
        /// </summary>
        /// <returns><c>true</c>, if check was drawn, <c>false</c> otherwise.</returns>
		static bool DrawCheck()
        {
            if ((Pos[0] != " " && IfWon() == false) &&
                (Pos[1] != " " && IfWon() == false) &&
                (Pos[2] != " " && IfWon() == false) &&
                (Pos[3] != " " && IfWon() == false) &&
                (Pos[4] != " " && IfWon() == false) &&
                (Pos[5] != " " && IfWon() == false) &&
                (Pos[6] != " " && IfWon() == false) &&
                (Pos[7] != " " && IfWon() == false) &&
                (Pos[8] != " " && IfWon() == false))
            {
                Console.WriteLine("Draw");
                resetPos();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Resets the position.
        /// </summary>
		static void resetPos()
        {
            Console.WriteLine("New game started !!! type Y to continue or N to exit");
            string x = Console.ReadLine().ToUpper();
            if (x != "N")
            {
                for (int j = 0; j <= 8; j++) Pos[j] = " ";
                PrintPos();
                Play();
            }
            else
            {
                Environment.Exit(1);
            }



        }
        /// <summary>
        /// Resets the position sec.
        /// </summary>
		static void resetPosSec()
        {
            Console.WriteLine("New game started !!! type Y to continue or N to exit");
            string x = Console.ReadLine().ToUpper();
            if (x != "N")
            {
                for (int j = 0; j <= 8; j++) Pos[j] = " ";
                PrintPos();
                PlayHuman();
            }
            else
            {
                Environment.Exit(1);
            }

        }



    }
}
