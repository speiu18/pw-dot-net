

namespace StackOverflow.Core
{
    public class BrowserOptions
    {
        public string BrowserType { get; set; } = "chromium"; // Default to Chromium
        public bool Headless { get; set; } = true; // Default to headless mode
        public int Timeout { get; set; } = 30000; // Default timeout in milliseconds
        public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3"; // Default user agent
    }
}
