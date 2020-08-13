using Safeon.Systems.Contracts;
using Safeon.Systems.Core.Settings;
using System;

namespace Safeon.IOC
{
    public class SettingsWrapper
    {
        private static ISettingsService settingsService;

        private static ISettingsService GetSettings()
        {
            if (settingsService != null)
                return settingsService;

            settingsService = Container.GetContainer().GetInstance<ISettingsService>();
            return settingsService;
        }
        
        public static R GetSetting<R>(Func<AppSettings, R> expressao)
        {
            var settings = GetSettings().GetAppSettings<AppSettings>();
            var result = expressao.Invoke(settings);
            return result;
        }
    }
}
