using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using TheInternetPage.PageObject;

namespace TheInternetPage.Tests;

[Parallelizable(ParallelScope.All)]
[TestFixture()]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class TheInternetPageTests : PageTest
{
    [Test]
    public async Task CheckmarkTest()
    {
        var theInternet = TheInternet.Initialize(Page);
        await theInternet.Open();
        var checkboxesPage = await theInternet.ClickCheckboxes();
        await checkboxesPage.SelectCheckboxOne();
        await checkboxesPage.UnSelectCheckboxTwo();
        
        Assert.That(await checkboxesPage.IsCheckBoxOneSelected(), Is.True);
        Assert.That(await checkboxesPage.IsCheckBoxTwoSelected(), Is.False);
    }

    [Test]
    public async Task LoginTest()
    {
        var theInternet = TheInternet.Initialize(Page);
        await theInternet.Open();
        var loginPage = await theInternet.ClickFormAuthentication();
        await loginPage.EnterUsername("tomsmith");
        await loginPage.EnterPassword("SuperSecretPassword!");
        var secureAreaPage = await loginPage.ClickLogin();

        StringAssert.Contains("You logged into a secure area!", await secureAreaPage.GetLoginStatus());
    }
}