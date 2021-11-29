using System;

namespace ShopSimulator
{
    public class Input
    {
        public static int EnterCountOfCashes()
        {
            int countOfCashes = 0;
            do
            {
                Console.WriteLine("Enter count of cashes (min = 1, max = 5): ");
                if (!int.TryParse(Console.ReadLine(), out countOfCashes) || countOfCashes > 5 || countOfCashes < 1)
                {
                    Console.WriteLine("Incorrect value!");
                    continue;
                }
                break;
            }
            while (true);
            return countOfCashes;
        }

        public static int EnterWorkTimeInSeconds()
        {
            int workTime = 0;
            do
            {
                Console.WriteLine("Enter shop work time (in seconds): ");
                if (!int.TryParse(Console.ReadLine(), out workTime) || workTime < 0)
                {
                    Console.WriteLine("Incorrect value!");
                    continue;
                }
                break;
            }
            while (true);
            return workTime;
        }
    }
}