using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe.TextConsoleTTT
{
    public static class SoloHardTTT
    {
        private static bool PutWinChar(char[] arr, char ch, int start, int end, bool horizontal = true)
        {
            //Horizontal case
            if (horizontal)
                for (int i = start; i <= end; i++)
                    arr[i] = ch;
            //Diagonal case
            else if (!horizontal && (end - start == 8 || end - start == 4)) 
            {
                if(end - start == 8)
                    for (int i = start; i <= end; i+=4)
                        arr[i] = ch;
                else
                    for (int i = start; i <= end; i += 2)
                        arr[i] = ch;
            }
            //Vertical case
            else
            {
                for (int i = start; i <= end; i += 3) 
                    arr[i] = ch;
            }
            return true;
        }

        private static bool PutSurvChar(char[] arr, char ch, int start, int end, bool horizontal = true)
        {
            //Horizontal case
            if (horizontal)
            {
                for (int i = start; i <= end; i++)
                    if (arr[i] == '-')
                    {
                        SoloTTT.ReduceArr(i);
                        arr[i] = ch;
                        return true;
                    }     
            }
            //Diagonal case
            else if (!horizontal && (end - start == 8 || end - start == 4))
            {
                if (end - start == 8)
                    for (int i = start; i <= end; i += 4)
                    {
                        if (arr[i] == '-')
                        {
                            SoloTTT.ReduceArr(i);
                            arr[i] = ch;
                            return true;
                        }
                    }
                else
                    for (int i = start; i <= end; i += 2)
                    {
                        if (arr[i] == '-')
                        {
                            SoloTTT.ReduceArr(i);
                            arr[i] = ch;
                            return true;
                        }
                    }  
            }
            //Vertical case
            else
            {
                for (int i = start; i <= end; i += 3)
                {
                    if (arr[i] == '-')
                    {
                        SoloTTT.ReduceArr(i);
                        arr[i] = ch;
                        return true;
                    }
                }    
            }
            return false;
        }

        public static bool WinningSpot(char[] arr,char oppositeCh, char ch)
        {
            int count = 0;

            //Check for horizontal winning codition
            for(int i = 1; i < 10; i++)
            {
                if (arr[i - 1] == oppositeCh)
                    count = 0;

                if (arr[i - 1] == ch)
                    count++;
                if (i % 3 == 0)
                {
                    if (count == 2)
                    {
                        return PutWinChar(arr, ch, (i - 1) - 2, (i - 1));
                    }    
                    count = 0;
                }
            }

            //Check for vertical winning codition
            count = 0;
            for (int i = 0; i < 9; i+=3)
            {
                if (arr[i] == oppositeCh)
                    count = 0;

                if (arr[i] == ch)
                    count++;

                if(i + 3 > 8)
                {
                    if (count == 2)
                    {
                        return PutWinChar(arr, ch, i - 6, i, false);
                    }

                    if (i == 8)
                        break;

                    count = 0;
                    i -= 8;
                }   
            }

            //Check for diagonal winning codition
            count = 0;
            for(int i = 0; i < 9; i+=4)
            {
                if (arr[i] == oppositeCh)
                    count = 0;

                if (arr[i] == ch)
                    count++;

                if (i == 8 && count == 2)
                {  
                    return PutWinChar(arr, ch, i - 8, i, false); ;
                }
                    
            }

            count = 0;
            for (int i = 2; i < 7; i += 2)
            {
                if (arr[i] == oppositeCh)
                    count = 0;

                if (arr[i] == ch)
                    count++;

                if (i == 6 && count == 2)
                {
                    return PutWinChar(arr, ch, i - 6, i - 4, false);
                }  
            }
            return false;
        }

        public static bool SurvivingSpot(char[] arr, char oppositeCh, char ch)
        {
            int count = 0;

            //Check for horizontal surviving codition
            for (int i = 1; i < 10; i++)
            {
                if (arr[i - 1] == oppositeCh)
                    count++;
                if (i % 3 == 0)
                {
                    if (count == 2)
                    {
                        return PutSurvChar(arr, ch, (i - 1) - 2, (i - 1));
                    }
                    count = 0;
                }
            }

            //Check for vertical surviving codition
            count = 0;
            for (int i = 0; i < 9; i += 3)
            {
                if (arr[i] == oppositeCh)
                    count++;

                if (i + 3 > 8)
                {
                    if (count == 2)
                    {
                        return PutSurvChar(arr, ch, i - 6, i, false);
                    }

                    if (i == 8)
                        break;

                    count = 0;
                    i -= 8;
                }
            }

            //Check for diagonal surviving codition
            count = 0;
            for (int i = 0; i < 9; i += 4)
            {
                if (arr[i] == oppositeCh)
                    count++;

                if (i == 8 && count == 2)
                {
                    return PutSurvChar(arr, ch, i - 8, i, false);
                }
            }

            count = 0;
            for (int i = 2; i < 7; i += 2)
            {
                if (arr[i] == oppositeCh)
                    count++;

                if (i == 6 && count == 2)
                {
                    return PutSurvChar(arr, ch, i - 6, i - 4, false);
                }
            }
            return false;
        }

    }
}
