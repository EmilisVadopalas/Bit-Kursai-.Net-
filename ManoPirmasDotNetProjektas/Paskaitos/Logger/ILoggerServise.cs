using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Logger
{
    public interface ILoggerServise
    {
        public Task LogWarning(string message);

        public Task LogError(string message);

        public Task LogInfo(string message);

        public Task LogDebug(string message);
    }
}
