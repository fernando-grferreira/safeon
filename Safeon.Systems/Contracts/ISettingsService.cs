namespace Safeon.Systems.Contracts
{
    public interface ISettingsService
    {
        T GetAppSettings<T>(bool updated = false) where T : IAppSettings, new();
        T GetSettings<T>() where T : class, new();
        T GetSettingsFromSection<T>(string sectionName) where T : class, new();
        T GetSettingsFromSection<T>() where T : class, ISectionSetting, new();
    }
}