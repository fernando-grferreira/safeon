using Safeon.Systems.Contracts;

namespace Safeon.Systems.Core.Settings
{
    public class AppSettings : IAppSettings
    {
        public string EnvironmentName { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }
    }
}