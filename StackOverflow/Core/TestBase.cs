using Microsoft.Playwright.NUnit;


namespace StackOverflow.Core
{
    public abstract class TestBase : PageTest
    {
        private static readonly PlaywrightConfiguration? _playwrightConfiguration;

        static TestBase()
        {
            _playwrightConfiguration = new PlaywrightConfiguration();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // This method is called once before any tests are run.
            // You can perform global setup here if needed.
            Console.WriteLine("Runnin global setup for Playwright tests...");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Console.WriteLine($"Runing tests against {_playwrightConfiguration.browserNewContextOptions.BaseURL}");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        [SetUp]
        public void SetUp()
        {
            // This method is called before each test.
            // You can perform setup specific to each test here.
            Console.WriteLine("Running setup for individual test...");
            this.Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true,
            }).GetAwaiter().GetResult();
        }

        [TearDown]  
        public void TearDown()
        {
            // This method is called after each test.
            // You can perform cleanup specific to each test here.
            Console.WriteLine("Running teardown for individual test...");
            this.Context.Tracing.StopAsync(new () { Path = "trace.zip"}).GetAwaiter().GetResult();
        }
    }
}
