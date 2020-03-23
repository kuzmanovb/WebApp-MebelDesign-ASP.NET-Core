using VehiclesExtension.Core;

namespace VehiclesExtension
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
