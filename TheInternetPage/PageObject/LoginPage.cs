using Microsoft.Playwright;

namespace TheInternetPage.PageObject;

public class LoginPage
{
    private readonly IPage _page;
    private readonly ILocator _userNameInput;
    private readonly ILocator _passwordInput;
    private readonly ILocator _loginButton;
    public LoginPage(IPage page) 
    {
        _page = page;
        _userNameInput = page.Locator("input[id='username']");
        _passwordInput = page.Locator("input[id='password']");
        _loginButton = page.Locator("button[type='submit']");
    }

    public async Task EnterUsername(string username)
    {            
        await _userNameInput.FillAsync(username);
    }

    public async Task EnterPassword(string password)
    {
        await _passwordInput.FillAsync(password);
    }

    public async Task<SecureAreaPage> ClickLogin()
    {
        await _loginButton.ClickAsync();
        return new(_page);
    }




}