using Styx.Common;

namespace Prosto_Pets
{
    public static class Logger
    {
        public static void Write(string message)
        {
            Logging.Write(System.Windows.Media.Colors.Gold, "[Pets] " + message);
        }
    
        public static void WriteDebug(string message)
        {
            // TODO: config
            Logging.Write(System.Windows.Media.Colors.LightBlue, "[PetD] " + message);
        }
        public static void Alert(string message)
        {
            // TODO: config
            Logging.Write(System.Windows.Media.Colors.Crimson, "[Pets] Alert: " + message);
        }
    }
}