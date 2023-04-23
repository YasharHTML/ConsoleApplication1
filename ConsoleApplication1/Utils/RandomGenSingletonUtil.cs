using System;

namespace ConsoleApplication1.Utils
{
    public class RandomGenSingletonUtil
    {
        public Random Random { get; }
        private static RandomGenSingletonUtil _instance;

        private RandomGenSingletonUtil()
        {
            this.Random = new Random();
        }

        public static RandomGenSingletonUtil getInstance()
        {
            return _instance ?? (_instance = new RandomGenSingletonUtil());
        }
    }
}