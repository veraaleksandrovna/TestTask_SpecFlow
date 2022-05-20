using OpenQA.Selenium;
using TestTask_SpecFlow.Services;

namespace TestTask_SpecFlow.Drivers;

public class BrowserService
{
    private IWebDriver _driver;

    public IWebDriver Driver
    {
        get => _driver;
        set => _driver = value;
    }
    public BrowserService()
    {
        Driver = Configurator.BrowserType.ToLower() switch
        {
            "chrome" => new DriverFactory().GetChromeDriver(),
            _ => Driver
        };

        Driver.Manage().Window.Maximize();
        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(0);
    }

    //public IWebDriver? Driver { get; set; }
}
