using TikTakToe.TextConsoleTTT;

namespace TikTakToe.TextConsoleTTT
{
    public static class DuoTTT
    {
        public static void PrintTable(char[] arr)
        {
            Console.WriteLine("    |   |     ");
            Console.WriteLine("  {0} | {1} | {2} ", arr[0], arr[1], arr[2]);
            Console.WriteLine("____|___|_____ ");
            Console.WriteLine("    |   |     ");
            Console.WriteLine("  {0} | {1} | {2} ", arr[3], arr[4], arr[5]);
            Console.WriteLine("____|___|_____ ");
            Console.WriteLine("    |   |     ");
            Console.WriteLine("  {0} | {1} | {2} ", arr[6], arr[7], arr[8]);
            Console.WriteLine("    |   | ");
        } 

        public static bool PutVal(char val,string name,  char[] arr)
        {
            PrintTable(arr);

            Console.WriteLine("{0}, enter position to put {1} : ",name ,val);
            try
            {
                int pos = Convert.ToInt32(Console.ReadLine());
                if (arr[pos] == '-')
                {
                    arr[pos] = val;
                    SoloTTT.ReduceArr(pos);
                    Console.Clear();
                } 
                else
                {
                    Console.WriteLine("Position is already occupied. Choose another one !");
                    return false;
                }
                
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
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
    }
}
