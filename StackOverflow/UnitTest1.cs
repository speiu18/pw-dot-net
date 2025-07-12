using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace StackOverflow;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class StakOverflowHome : PageTest
{
    private readonly string appUrl = "https://stackoverflow.com/";








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
        var navigationItems =  Page.Locator("div.s-topbar--container > ol.s-navigation");
        var aboutLink = navigationItems.GetByText("About");

        // Expects page to have a heading with the name of Installation.  
        await Expect(aboutLink).ToBeVisibleAsync();
    }
}