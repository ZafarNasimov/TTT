﻿using static TikTakToe.TextConsoleTTT.SoloEasyTTT;

namespace TikTakToe.TextConsoleTTT
{
    public static class SoloHardTTT
    {
        public static bool ScanHardHorizontal(int pos, char ch, char oppositeCh, char[] arr)
        {
            int count = 0;
            int start = pos / 3;
            for (int i = start * 3; i < start * 3 + 3; i++)
            {
                if (arr[i] == oppositeCh)
                    return false;
                else if(arr[i] == ch)
                    count++;
            }
            return count > 0;
        }

        public static bool ScanHardVertical(int pos, char ch, char oppositeCh, char[] arr)
        {
            int count = 0;
            int start = pos % 3;
            for (int i = start; i <= start + 6; i += 3)
            {
                if (arr[i] == oppositeCh)
                    return false;
                else if (arr[i] == ch)
                    count++;
            }
            return count > 0;
        }

        public static bool ScanHardDiagonal(int pos, char ch, char oppositeCh, char[] arr)
        {
            bool mod8 = pos % 8 == 0;
            bool mod2 = pos % 2 == 0;
            bool eq4 = pos == 4;

            int count = 0;
            if (mod8 || eq4)
            {
                for (int i = 0; i <= 8; i += 4)
                {
                    if (arr[i] == oppositeCh)
                        return false;
                    else if (arr[i] == ch)
                        count++;
                }
            }
            if(count > 0)
                return true;
            
            count = 0;
            if ((!mod8 && mod2) || eq4 )
            {
                for (int i = 2; i <= 6; i += 2)
                {
                    if (arr[i] == oppositeCh)
                        return false;
                    else if (arr[i] == ch)
                        count++;
                }
            }

            return count > 0;
        }

        public static bool HardWinningSpot(char ch, char oppositeCh, char[] arr, bool survive = false)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '-')
                {
                    if ((ScanHardHorizontal(i, ch, oppositeCh, arr) && ScanHardVertical(i, ch, oppositeCh, arr)) ||
                    (ScanHardDiagonal(i, ch, oppositeCh, arr) && ScanHardVertical(i, ch, oppositeCh, arr)) ||
                    (ScanHardDiagonal(i, ch, oppositeCh, arr) && ScanHardHorizontal(i, ch, oppositeCh, arr)))
                    {
                        ReduceArr(i);
                        if(!survive) 
                            arr[i] = ch;
                        else
                            arr[i] = oppositeCh;
                        Console.WriteLine("Hard bot made move !");
                        return true;
                    }
                }
            }
            return false;
        }

        public static void HardBotBeginningLogic(char ch, char[] arr)
        {
            int pos;
            do
            {
                Random random = new Random();
                pos = 2 * random.Next(0, arr.Length / 2);
            } while (arr[pos] != '-');
            
            arr[pos] = ch;
            ReduceArr(pos);
            Console.WriteLine("Hard bot made first move !");
        }

    }
}
