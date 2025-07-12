using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using StackOverflow.Core;

namespace StackOverflow;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class StakOverflowHome : TestBase
{
    private string appUrl;

    [SetUp]
    public void SetUp()
    {
        // Load configuration settings 
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("TEST_ENVIRONMENT")}.json", optional: true)
            .AddEnvironmentVariables()  
            .Build();

        // You can access configuration settings here if needed  
        appUrl = config["appUrl"];
        Console.WriteLine($"{config["user"]}");
    }

    [Test]
    public async Task HasTitle()
    {
        await Page.GotoAsync(appUrl);

        // Expect a title "to contain" a substring.  
        await Expect(Page).ToHaveTitleAsync("Newest Questions - Stack Overflow");
    }

    [Test]
    public async Task AboutLink()
    {
        await Page.GotoAsync(appUrl);

        // Click the get started link.  
        var navigationItems = Page.Locator("div.s-topbar--container > ol.s-navigation");
        var aboutLink = navigationItems.GetByText("About");

        // Expects page to have a heading with the name of Installation.  
        await Expect(aboutLink).ToBeVisibleAsync();
    }
}