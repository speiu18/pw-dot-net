using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace StackOverflow;

public class SOflw: PageTest
{
    private string appUrl;




    [SetUp]
    public void Setup()
    {
        // Load configuration settings 
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        // You can access configuration settings here if needed  
        appUrl = config["appUrl"] ?? "https://stackoverflow.com";
    }

    [Test]
    [Description("Check if the StackOverflow login and sign up links are visible on the homepage")]
    public async Task Login_and_sign_up_visible()
    {
        await Page.GotoAsync(appUrl);
        // Check if the login link is visible
        var loginLink = Page.GetByRole(Microsoft.Playwright.AriaRole.Menuitem).GetByText("Log in");

        await Expect(loginLink).ToBeVisibleAsync();

    }
}
