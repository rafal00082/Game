using System.Threading.Tasks;

namespace Simple.Game.Abstract.Initialize
{
    public interface IDbInicializer
    {
        public Task SeedInitData();
    }
}
