using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace TestTask_SpecFlow.Services;

public static class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;

    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    public static IConfiguration Configuration => s_configuration.Value;

    public static string BaseUrl => Configuration[nameof(BaseUrl)];
    public static string BrowserType => Configuration[nameof(BrowserType)];
    public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles) builder.AddJsonFile(appSettingFile);

        return builder.Build();
    }
}
