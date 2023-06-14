using static System.Console;
using static System.Convert;
using static TikTakToe.TextConsoleTTT.SoloEasyTTT;

namespace TikTakToe.TextConsoleTTT
{
    public static class BaseDuoTTT
    {
        public static void PrintTable(char[] arr)
        {
            WriteLine("    |   |     ");
            WriteLine("  {0} | {1} | {2} ", arr[0], arr[1], arr[2]);
            WriteLine("____|___|_____ ");
            WriteLine("    |   |     ");
            WriteLine("  {0} | {1} | {2} ", arr[3], arr[4], arr[5]);
            WriteLine("____|___|_____ ");
            WriteLine("    |   |     ");
            WriteLine("  {0} | {1} | {2} ", arr[6], arr[7], arr[8]);
            WriteLine("    |   | ");
        } 

        public static bool PutVal(char val,string name,  char[] arr)
        {
            PrintTable(arr);

            WriteLine("{0}, enter position to put {1} : ",name ,val);
            try
            {
                int pos = ToInt32(ReadLine());
                if (arr[pos] == '-')
                {
                    arr[pos] = val;
                    ReduceArr(pos);
                    Clear();
                } 
                else
                {
                    WriteLine("Position is already occupied. Choose another one !");
                    return false;
                }
                
            }
            catch (IndexOutOfRangeException ex)
            {
                WriteLine(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
                return false;
            }
            catch (FormatException ex)
            {
                WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public static int CheckWinOrDraw(char[] arr)
        {
            if (arr[0] == arr[1] && arr[1] == arr[2] && arr[0] != '-')
                return 1;
            else if (arr[3] == arr[4] && arr[4] == arr[5] && arr[5] != '-')
                return 1;
            else if (arr[6] == arr[7] && arr[7] == arr[8] && arr[8] != '-')
                return 1;
            else if (arr[0] == arr[3] && arr[3] == arr[6] && arr[6] != '-')
                return 1;
            else if (arr[1] == arr[4] && arr[4] == arr[7] && arr[7] != '-')
                return 1;
            else if (arr[2] == arr[5] && arr[5] == arr[8] && arr[8] != '-')
                return 1;
            else if (arr[0] == arr[4] && arr[4] == arr[8] && arr[8] != '-')
                return 1;
            else if (arr[2] == arr[4] && arr[4] == arr[6] && arr[6] != '-')
                return 1;
            else return 0;
        }

        public static bool IsEmpty(int pos, char[] arr)
        {
            return arr[pos] == '-';
        }
    }
}
