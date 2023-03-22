using Microsoft.Playwright;
using static NUnit.Framework.TestContext;

namespace TheInternetPage.PageObject;

public class TheInternet
{
    private readonly IPage _page;
    private readonly ILocator _checkboxLink;
    private readonly ILocator _formAuthentication;

    public static TheInternet Initialize(IPage page)
    {
        return new TheInternet(page);
    }
    public TheInternet(IPage page)
    {
        _page = page;
        _checkboxLink = page.Locator("a[href='/checkboxes']");
        _formAuthentication = page.Locator("a[href='/login']");
    }

    public async Task OpenAsync()
    {
        await _page.GotoAsync(url: Parameters.Get("url"));
        await _checkboxLink.WaitForAsync(new() { State = WaitForSelectorState.Visible });
    }

    public async Task<CheckboxesPage> ClickCheckboxesAsync()
    {
        await _checkboxLink.ClickAsync();
        return new(_page);
    }

    public async Task<LoginPage> ClickFormAuthenticationAsync()
    {
        await _formAuthentication.ClickAsync();
        return new(_page);
    }
}
