using Microsoft.Playwright;

namespace TheInternetPage.PageObject;

public class SecureAreaPage
{
    private readonly IPage _page;
    private readonly ILocator _header;
    private readonly ILocator _status;

    public SecureAreaPage(IPage page) 
    {
        _page = page;
        _header = page.Locator("//h2[contains(text(),'Secure Area')]");
        _status = page.Locator("div[id='flash']");
        _header.WaitForAsync(new() { State = WaitForSelectorState.Visible }).Wait();
    }

    public async Task<string> GetLoginStatus()
    {
        return await _status.InnerTextAsync();
    }


}