using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe.TextConsoleTTT;

namespace TikTakToe.TextConsoleTTT
{
    public static class SoloTTT
    {
        static List<int> static_list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        public static void ReduceArr(int value)
        {
            static_list.Remove(value);
        }

        public static int ChooseSpot()
        {
            Random random = new Random();
            return random.Next(0, static_list.Count);
        }

        public static void EasyModeTTTLogic(char val,char[] arr)
        {
            int random_pos = ChooseSpot();
            arr[static_list.ElementAt(random_pos)] = val;
            ReduceArr(static_list.ElementAt(random_pos));
        }
    }
}
