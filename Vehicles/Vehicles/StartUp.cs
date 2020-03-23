using Vehicles.Core;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
