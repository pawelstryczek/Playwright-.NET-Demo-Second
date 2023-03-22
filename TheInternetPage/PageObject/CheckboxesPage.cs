using Microsoft.Playwright;

namespace TheInternetPage.PageObject;

public class CheckboxesPage
{
    private readonly IPage _page;
    private readonly ILocator _header;
    private readonly ILocator _checkboxes;

    public CheckboxesPage(IPage page)
    {
        _page = page;
        _header = page.Locator("//h3[text()='Checkboxes']");
        _checkboxes = page.Locator("input");
    }

    public async Task SelectCheckboxOneAsync()
    {
        await _checkboxes.Nth(0).CheckAsync();
    }
    public async Task UnSelectCheckboxTwoAsync()
    {
        await _checkboxes.Nth(1).UncheckAsync();
    }

    public async Task<bool> IsCheckBoxOneSelectedAsync()
    {
        return await _checkboxes.Nth(0).IsCheckedAsync();
    }
    public async Task<bool> IsCheckBoxTwoSelectedAsync()
    {
        return await _checkboxes.Nth(1).IsCheckedAsync();
    }
}
