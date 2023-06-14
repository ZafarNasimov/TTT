using static System.Console;
using static System.Convert;
using static TikTakToe.TextConsoleTTT.BaseDuoTTT;
using static TikTakToe.TextConsoleTTT.SoloEasyTTT;
using static TikTakToe.TextConsoleTTT.SoloMediumTTT;
using static TikTakToe.TextConsoleTTT.SoloHardTTT;


namespace TikTakToe.Main
{
    public class Program
    {
        static int Main()
        {
            char[] arr = { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
            char ch1 = 'x';
            char ch2 = '0';
            string? name1, name2;
            int flag = 0;

            WriteLine("Choose mode : ");
            WriteLine(" [1] Multiplayer ");
            WriteLine(" [2] Play vs Easy Bot ");
            WriteLine(" [3] Play vs Medium Bot ");
            WriteLine(" [4] Play vs Hard Bot ");

            int mode_choice = ToInt32(ReadLine());

            switch (mode_choice)
            {
                case 1:
                    WriteLine("First player`s name (x): ");
                    name1 = ReadLine();
                    WriteLine("Second player`s name (0): ");
                    name2 = ReadLine();

                    if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
                    {
                        WriteLine("Wrong input to Name: do not leave empty spaced !");
                        goto case 1;
                    }


                    while (true)
                    {
                        if (flag == 0)
                        {
                            if (PutVal(ch1, name1, arr))
                                flag++;

                            if (CheckWinOrDraw(arr) == 1)
                            {
                                WriteLine("{0} won ! ", name1);
                                break;
                            }
                        }
                        else
                        {
                            if (PutVal(ch2, name2, arr))
                                flag--;
                            if (CheckWinOrDraw(arr) == 1)
                            {
                                WriteLine("{0} won ! ", name2);
                                break;
                            }
                        }
                        if (!new string(arr).Contains('-'))
                        {
                            WriteLine("Draw ! ");
                            break;
                        }
                    }
                    break;
                case 2:
                    WriteLine("Play for [1] 'x' or [2] '0' ? : ");
                    int side_choice = ToInt32(ReadLine());
                    bool is_bot_turn;

                    if (side_choice == 1)
                    {
                        is_bot_turn = false;
                        WriteLine("First player`s name (x): ");
                        name1 = ReadLine();
                        name2 = "Karl";
                        WriteLine("Second player`s name (0): {0}", name2);
                    }
                    else
                    {
                        is_bot_turn = true;
                        (ch1, ch2) = (ch2, ch1);
                        name2 = "Karl";
                        WriteLine("First player`s name (x): {0}", name2);
                        WriteLine("Second player`s name (0): ");
                        name1 = ReadLine();
                    }

                    if (string.IsNullOrEmpty(name1))
                    {
                        WriteLine("Wrong input to Name: do not leave empty spaced !");
                        goto case 2;
                    }


                    while (true)
                    {

                        if (is_bot_turn)
                        {
                            EasyModeTTTLogic(ch2, arr);
                            is_bot_turn = false;
                            if (CheckWinOrDraw(arr) == 1)
                            {
                                PrintTable(arr);
                                WriteLine("{0} won ! ", name2);
                                break;
                            }
                        }
                        else if (PutVal(ch1, name1, arr))
                        {
                            is_bot_turn = true;
                            if (CheckWinOrDraw(arr) == 1)
                            {
                                PrintTable(arr);
                                WriteLine("{0} won ! ", name1);
                                break;
                            }
                        }


                        if (!new string(arr).Contains('-'))
                        {
                            WriteLine("Draw ! ");
                            break;
                        }
                    }
                    break;
                case 3:
                    WriteLine("Play for [1] 'x' or [2] '0' ? : ");
                    side_choice = ToInt32(ReadLine());

                    if (side_choice == 1)
                    {
                        is_bot_turn = false;
                        WriteLine("First player`s name (x): ");
                        name1 = ReadLine();
                        name2 = "Shahboz";
                        WriteLine("Second player`s name (0): {0}", name2);
                    }
                    else
                    {
                        is_bot_turn = true;
                        (ch1, ch2) = (ch2, ch1);
                        name2 = "Shahboz";
                        WriteLine("First player`s name (x): {0}", name2);
                        WriteLine("Second player`s name (0): ");
                        name1 = ReadLine();
                    }

                    if (string.IsNullOrEmpty(name1))
                    {
                        WriteLine("Wrong input to Name: do not leave empty spaced !");
                        goto case 3;
                    }

                    while (true)
                    {
                        if (is_bot_turn)
                        {
                            if (!MediumWinningSpot(ch2, ch1, arr))
                            {
                                if (!MediumWinningSpot(ch1, ch2, arr, true))
                                {
                                    EasyModeTTTLogic(ch2, arr);
                                }
                            }
                                

                            is_bot_turn = false;
                            if (CheckWinOrDraw(arr) == 1)
                            {
                                PrintTable(arr);
                                WriteLine("{0} won ! ", name2);
                                break;
                            }
                        }
                        else if (PutVal(ch1, name1, arr))
                        {
                            is_bot_turn = true;
                            if (CheckWinOrDraw(arr) == 1)
                            {
                                PrintTable(arr);
                                WriteLine("{0} won ! ", name1);
                                break;
                            }
                        }


                        if (!new string(arr).Contains('-'))
                        {
                            WriteLine("Draw ! ");
                            break;
                        }
                    }
                    break;
                case 4:
                    WriteLine("Play for [1] 'x' or [2] '0' ? : ");
                    side_choice = ToInt32(ReadLine());

                    if (side_choice == 1)
                    {
                        is_bot_turn = false;
                        WriteLine("First player`s name (x): ");
                        name1 = ReadLine();
                        name2 = "Zafar";
                        WriteLine("Second player`s name (0): {0}", name2);
                    }
                    else
                    {
                        is_bot_turn = true;
                        (ch1, ch2) = (ch2, ch1);
                        name2 = "Zafar";
                        WriteLine("First player`s name (x): {0}", name2);
                        WriteLine("Second player`s name (0): ");
                        name1 = ReadLine();
                    }

                    if (string.IsNullOrEmpty(name1))
                    {
                        WriteLine("Wrong input to Name: do not leave empty spaced !");
                        goto case 3;
                    }

                    int move_count = 0;
                    while (true)
                    {
                        if (is_bot_turn)
                        {
                            if (move_count == 1)
                            {
                                HardBotBeginningLogic(ch2, arr);
                            }
                            else if (!MediumWinningSpot(ch2, ch1, arr))
                            {
                                if (!MediumWinningSpot(ch1, ch2, arr, true))
                                {
                                    if (!HardWinningSpot(ch2, ch1, arr))
                                    {
                                        if(!HardWinningSpot(ch1, ch2, arr, true))
                                        {
                                            EasyModeTTTLogic(ch2, arr);
                                        }  
                                    }
                                }
                            }

                            move_count++;
                            is_bot_turn = false;
                            if (CheckWinOrDraw(arr) == 1)
                            {
                                PrintTable(arr);
                                WriteLine("{0} won ! ", name2);
                                break;
                            }
                        }
                        else if (PutVal(ch1, name1, arr))
                        {
                            move_count++;
                            is_bot_turn = true;
                            if (CheckWinOrDraw(arr) == 1)
                            {
                                PrintTable(arr);
                                WriteLine("{0} won ! ", name1);
                                break;
                            }
                        }


                        if (!new string(arr).Contains('-'))
                        {
                            PrintTable(arr);
                            WriteLine("Draw ! ");
                            break;
                        }
                    }
                    break;
            }
            return 0;
        }
    }
}

