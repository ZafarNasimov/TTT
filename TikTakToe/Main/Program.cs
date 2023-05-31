using TikTakToe.TextConsoleTTT;

namespace TikTakToe.Main
{
    public class Program
    {
        static int Main()
        {
            char[] arr = { '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            char ch1 = 'x';
            char ch2 = '0';
            int flag = 0;


            string name1, name2;
            Console.WriteLine("First player`s name (x): ");
            name1 = Console.ReadLine();
            Console.WriteLine("Second player`s name (0): ");
            name2 = Console.ReadLine();

            while(true)
            {
                if (flag == 0)
                {
                    if(DuoTextConsoleTTT.PutVal(ch1, name1, arr))
                        flag++;

                    if (DuoTextConsoleTTT.CheckWinOrDraw(arr) == 1)
                    {
                        Console.WriteLine("{0} won ! ", name1);
                        break;
                    }
                }
                else
                {
                    if(DuoTextConsoleTTT.PutVal(ch2, name2, arr))
                        flag--;
                    if (DuoTextConsoleTTT.CheckWinOrDraw(arr) == 1)
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
            return 0;
        }
    }
}
