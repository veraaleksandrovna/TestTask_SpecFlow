using OpenQA.Selenium;

namespace TestTask_SpecFlow.Pages;

public class DropDownPage: BasePage
{
    private static readonly By LogoBy = By.Id("logo");
    private static readonly By DropDownBy = By.TagName("select");
    
    public IWebElement Logo => WaitService.WaitUntilElementExists(LogoBy);
    public IWebElement DropDown => WaitService.WaitUntilElementExists(DropDownBy);
    public DropDownPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return LogoBy;
    }
}
