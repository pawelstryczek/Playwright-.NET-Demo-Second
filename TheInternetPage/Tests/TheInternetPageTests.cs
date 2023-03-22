using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using TheInternetPage.PageObject;
using static NUnit.Framework.TestContext;

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
        await theInternet.OpenAsync();
        var checkboxesPage = await theInternet.ClickCheckboxesAsync();
        await checkboxesPage.SelectCheckboxOneAsync();
        await checkboxesPage.UnSelectCheckboxTwoAsync();
        
        Assert.That(await checkboxesPage.IsCheckBoxOneSelectedAsync(), Is.True);
        Assert.That(await checkboxesPage.IsCheckBoxTwoSelectedAsync(), Is.False);
    }

    [Test]
    public async Task LoginTest()
    {
        var theInternet = TheInternet.Initialize(Page);
        await theInternet.OpenAsync();
        var loginPage = await theInternet.ClickFormAuthenticationAsync();
        await loginPage.EnterUsernameAsync(username: Parameters.Get("username"));
        await loginPage.EnterPasswordAsync(password: Parameters.Get("password"));
        var secureAreaPage = await loginPage.ClickLoginAsync();

        StringAssert.Contains("You logged into a secure area!", await secureAreaPage.GetLoginStatusAsync());
    }
}