using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestTask_SpecFlow.Drivers;

namespace TestTask_SpecFlow.Hooks;

[Binding]
public class Hook
{
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver? Driver;

    public Hook(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    
    [BeforeScenario("DropDownValues")]
    public void BeforeScenario()
    {
        Driver = new BrowserService().Driver;
        _scenarioContext.Add("Driver", Driver);
    }

    [AfterScenario("DropDownValues")]
    public void AfterScenario()
    {
        Driver?.Quit();
        _scenarioContext.Remove("Driver");
    }
}
