using System.Threading.Tasks;

namespace ShopSimulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int countOfCashes = Input.EnterCountOfCashes();
            int workTimeInSeconds = Input.EnterWorkTimeInSeconds();
            Shop shop = new Shop(countOfCashes, workTimeInSeconds);
            Task.Factory.StartNew(() => shop.Run()).Wait();
        }
    }
}