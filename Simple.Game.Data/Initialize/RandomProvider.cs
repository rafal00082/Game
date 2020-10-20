using Simple.Game.Abstract.Initialize;
using System;

namespace Simple.Game.Data.Initialize
{
    public class RandomProvider : IRandomProvider
    {
        private Random random = new Random();

        public int Next(int min, int max)
        {
            return random.Next(min, max);
        }

        public double NextDouble()
        {
            return random.NextDouble();
        }
    }
}
