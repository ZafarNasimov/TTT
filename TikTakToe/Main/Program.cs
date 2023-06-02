using TikTakToe.TextConsoleTTT;
using static System.Console;

namespace TikTakToe.Main
{
    public class Program
    {
        static int Main()
        {
            //char[] test_arr = { '-', '-', '-', '-', 'x', '-', '-', '-', 'x' };
            //char test_char = '0';
            //char testOppositeChar = 'x';
            //SoloHardTTT.SurvivingSpot(test_arr, testOppositeChar, test_char);
            //foreach (char c in test_arr)
            //    Write($"{c} ");


            char[] arr = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
            char ch1 = 'x';
            char ch2 = '0';
            string name1, name2;
            int flag = 0;

            Console.WriteLine("Choose mode : ");
            Console.WriteLine(" [1] Multiplayer ");
            Console.WriteLine(" [2] Play vs Easy Bot ");
            Console.WriteLine(" [3] Play vs Hard Bot ");

            int mode_choice = Convert.ToInt32(Console.ReadLine());
            switch (mode_choice)
            {
                case 1:
                    Console.WriteLine("First player`s name (x): ");
                    name1 = Console.ReadLine();
                    Console.WriteLine("Second player`s name (0): ");
                    name2 = Console.ReadLine();

                    while (true)
                    {
                        if (flag == 0)
                        {
                            if (DuoTTT.PutVal(ch1, name1, arr))
                                flag++;

                            if (DuoTTT.CheckWinOrDraw(arr) == 1)
                            {
                                Console.WriteLine("{0} won ! ", name1);
                                break;
                            }
                        }
                        else
                        {
                            if (DuoTTT.PutVal(ch2, name2, arr))
                                flag--;
                            if (DuoTTT.CheckWinOrDraw(arr) == 1)
                            {
                                Console.WriteLine("{0} won ! ", name2);
                                break;
                            }
                        }
                        if (!new string(arr).Contains('-'))
                        {
                            Console.WriteLine("Draw ! ");
                            break;
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Play for [1] 'x' or [2] '0' ? : ");
                    int side_choice = Convert.ToInt32(Console.ReadLine());
                    bool is_bot_turn;

                    if (side_choice == 1)
                    {
                        is_bot_turn = false;
                        Console.WriteLine("First player`s name (x): ");
                        name1 = Console.ReadLine();
                        name2 = "Karl";
                        Console.WriteLine("Second player`s name (0): {0}", name2);
                    }
                    else
                    {
                        is_bot_turn = true;
                        (ch1, ch2) = (ch2, ch1);
                        name2 = "Karl";
                        Console.WriteLine("First player`s name (x): {0}", name2);
                        Console.WriteLine("Second player`s name (0): ");
                        name1 = Console.ReadLine();
                    }


                    while (true)
                    {

                        if (is_bot_turn)
                        {
                            SoloTTT.EasyModeTTTLogic(ch2, arr);
                            is_bot_turn = false;
                            if (DuoTTT.CheckWinOrDraw(arr) == 1)
                            {
                                DuoTTT.PrintTable(arr);
                                Console.WriteLine("{0} won ! ", name2);
                                break;
                            }
                        }
                        else if (DuoTTT.PutVal(ch1, name1, arr))
                        {
                            is_bot_turn = true;
                            if (DuoTTT.CheckWinOrDraw(arr) == 1)
                            {
                                DuoTTT.PrintTable(arr);
                                Console.WriteLine("{0} won ! ", name1);
                                break;
                            }
                        }


                        if (!new string(arr).Contains('-'))
                        {
                            Console.WriteLine("Draw ! ");
                            break;
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Play for [1] 'x' or [2] '0' ? : ");
                    side_choice = Convert.ToInt32(Console.ReadLine());

                    if (side_choice == 1)
                    {
                        is_bot_turn = false;
                        Console.WriteLine("First player`s name (x): ");
                        name1 = Console.ReadLine();
                        name2 = "Shahboz";
                        Console.WriteLine("Second player`s name (0): {0}", name2);
                    }
                    else
                    {
                        is_bot_turn = true;
                        (ch1, ch2) = (ch2, ch1);
                        name2 = "Shahboz";
                        Console.WriteLine("First player`s name (x): {0}", name2);
                        Console.WriteLine("Second player`s name (0): ");
                        name1 = Console.ReadLine();
                    }


                    while (true)
                    {
                        if (is_bot_turn)
                        {
                            if (!SoloHardTTT.WinningSpot(arr, ch1, ch2))
                                if (!SoloHardTTT.SurvivingSpot(arr, ch1, ch2))
                                {
                                    SoloTTT.EasyModeTTTLogic(ch2, arr);
                                }
                                    
                            is_bot_turn = false;
                            if (DuoTTT.CheckWinOrDraw(arr) == 1)
                            {
                                DuoTTT.PrintTable(arr);
                                Console.WriteLine("{0} won ! ", name2);
                                break;
                            }
                        }
                        else if (DuoTTT.PutVal(ch1, name1, arr))
                        {
                            is_bot_turn = true;
                            if (DuoTTT.CheckWinOrDraw(arr) == 1)
                            {
                                DuoTTT.PrintTable(arr);
                                Console.WriteLine("{0} won ! ", name1);
                                break;
                            }
                        }


                        if (!new string(arr).Contains('-'))
                        {
                            Console.WriteLine("Draw ! ");
                            break;
                        }
                    }
                    break;
            }
            return 0;
        }
    }
}

