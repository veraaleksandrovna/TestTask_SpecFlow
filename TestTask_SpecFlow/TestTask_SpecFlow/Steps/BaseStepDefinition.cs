using OpenQA.Selenium;

namespace TestTask_SpecFlow.Steps;

public class BaseStepDefinition
{
    private IWebDriver _driver;
    public BaseStepDefinition(ScenarioContext scenarioContext)
    {
        _driver = (IWebDriver)scenarioContext["Driver"];
    }

    protected IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}
