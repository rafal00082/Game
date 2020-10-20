namespace Simple.Game.Abstract.Initialize
{
    public interface IRandomProvider
    {
        public double NextDouble();
        public int Next(int min, int max);
    }
}
