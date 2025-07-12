using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;


namespace StackOverflow.Core
{
   
    public class PlaywrightConfiguration
    {
        public readonly BrowserOptions? browserOptions;
        public readonly BrowserNewContextOptions? browserNewContextOptions;


        public PlaywrightConfiguration()
        {

            browserOptions = ConfigurationManager.GetConfigurationSection("BrowserOptions").Get<BrowserOptions>();
            browserNewContextOptions = new BrowserNewContextOptions
            {
                AcceptDownloads = true,
                IgnoreHTTPSErrors = true,
                UserAgent = browserOptions?.UserAgent ?? "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3",
                
            };
        }

    }
}
