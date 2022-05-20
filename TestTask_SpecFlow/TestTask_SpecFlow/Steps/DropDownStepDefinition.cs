using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestTask_SpecFlow.Pages;

namespace TestTask_SpecFlow.Steps;

[Binding]
public class DropDownStepDefinition: BaseStepDefinition
{
    private readonly DropDownPage _dropDownPage;
    

    public DropDownStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {

        _dropDownPage = new DropDownPage(Driver);
    }
    
    [Given(@"dropdown page is opened")]
    public void GivenDropdownPageIsOpened()
    {
       _dropDownPage.OpenPage();
       Assert.IsTrue(_dropDownPage.PageOpened);
       
    }

    [Given(@"dropdown element was found")]
    public void GivenDropdownElementWasFound()
    {
        Assert.That(_dropDownPage.DropDown.Displayed);
    }

    [Then(@"count dropdown elements")]
    public void ThenCountDropdownElements()
    {
        SelectElement selectList = new SelectElement(Driver.FindElement(By.TagName("select")));
        IList<IWebElement> elementCount = selectList.Options;
        
        var expectedValue = 249;
        var countOptions = elementCount.Count;
        countOptions.Should().Be(expectedValue);

        Console.Out.WriteAsync($"quantity of select options is " + countOptions);
    }
    
}
