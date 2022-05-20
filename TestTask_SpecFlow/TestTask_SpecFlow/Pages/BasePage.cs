using OpenQA.Selenium;
using TestTask_SpecFlow.Services;

namespace TestTask_SpecFlow.Pages;


        public abstract class BasePage
        {
            private IWebDriver Driver { get; }
    
            protected static WaitService WaitService { get; private set; } = null!;
    
            public bool PageOpened => WaitService.WaitUntilElementExists(GetPageIdentifier()).Displayed;
    
            protected BasePage(IWebDriver driver)
            {
                Driver = driver;
                WaitService = new WaitService(Driver);
            }
            
            public void OpenPage()
            {
                Driver.Navigate().GoToUrl(Configurator.BaseUrl);
            }
    
            protected abstract By GetPageIdentifier();
        }
