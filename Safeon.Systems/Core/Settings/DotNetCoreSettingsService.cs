using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Safeon.Systems.Contracts;
using Safeon.Systems.Utils.Extensions;
using System;
using System.IO;
using System.Linq;

namespace Safeon.Systems.Core.Settings
{
    public class DotNetCoreSettingsService : ISettingsService
    {
        private static IAppSettings appSettings;
        private readonly IHostingEnvironment _env;

        public DotNetCoreSettingsService(IHostingEnvironment env)
        {
            _env = env;
        }

        private IConfigurationRoot GetConfigurationRoot()
        {
            var environment = Environment.GetEnvironmentVariable("APP_ENVIRONMENT");
            var jsonFileName = "appsettings.json";

            if (!string.IsNullOrWhiteSpace(environment))
                jsonFileName = $"appsettings.{environment.ToTitleCase()}.json";

            var builder = new ConfigurationBuilder()
                                .SetBasePath(_env.ContentRootPath)
                                .AddJsonFile(jsonFileName, optional: false, reloadOnChange: true)
                                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            return configuration;
        }

        private T GetAppSettingsUpdated<T>()
            where T : IAppSettings, new()
        {
            IConfigurationRoot configuration = GetConfigurationRoot();

            var config = new { AppSettings = new T() };
            configuration.Bind(config);

            return config.AppSettings;
        }

        public T GetAppSettings<T>(bool updated = false) where T : IAppSettings, new()
        {
            if (appSettings != null)
                return (T)appSettings;

            var config = GetAppSettingsUpdated<T>();

            appSettings = config;

            return config;
        }

        public T GetSettings<T>() where T : class, new()
        {
            var sectionName = "AppSettings";
            try
            {
                IConfigurationRoot configuration = GetConfigurationRoot();

                var section = configuration.GetSection(sectionName);
                var childs = section.GetChildren();

                var type = typeof(T);
                var className = type.Name;

                var first = childs.FirstOrDefault(x => x.Key == className);
                return first.Get<T>();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Não foi possível recuperar as configurações na seção de configuração padrão: {sectionName}. Verifique se as configurações foram criadas.", ex);
            }
        }

        /// <summary>
        /// Recupera uma configuração presente em um nome de seção.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto que representa a configuração desejada. Ex: tipo da implementação de TelemetryConfigurationBase</typeparam>
        /// <param name="sectionName">Nome da seção onde reside as configurações</param>
        /// <returns></returns>
        public T GetSettingsFromSection<T>(string sectionName) where T : class, new()
        {
            try
            {
                IConfigurationRoot configuration = GetConfigurationRoot();
                var section = configuration.GetSection(sectionName);

                var config = section.Get<T>();

                if (config == null)
                {
                    throw new ArgumentNullException("ConfigurationSectionName");
                }

                return config;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Não foi possível recuperar as configurações na seção de configuração: {sectionName}. Verifique se as configurações foram criadas.", ex);
            }
        }

        public T GetSettingsFromSection<T>() where T : class, ISectionSetting, new()
        {
            return GetSettingsFromSection<T>(new T().SectionName);
        }
    }
}
