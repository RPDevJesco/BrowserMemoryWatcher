using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

namespace TestingBrowerPageInfo
{
    public class Info
    {
        private string baseURL = "https://rpdevjesco.github.io/MWC/";
        public void GetInfo()
        {
            string browser = GetUserInput("Enter the browser type (chrome, firefox, edge) or leave blank to use Chrome: ");
            string url = GetUserInput("Enter the URL to navigate to or leave blank to use https://example.com: ");
            InitializeBrowser(browser, url);
        }

        private string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine().Trim();
        }

        private void InitializeBrowser(string browserType, string url)
        {
            switch (browserType.ToLower())
            {
                case "edge":
                    InitializeEdge(url);
                    break;
                case "chrome":
                default:
                    InitializeChrome(url);
                    break;
            }
        }

        private void InitializeChrome(string url)
        {
            // Initialize ChromeDriver
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--enable-precise-memory-info"); // Enable precise memory info
            IWebDriver driver = new ChromeDriver(options);
            // Cast driver to IJavaScriptExecutor
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            try
            {
                if (url == "") url = baseURL;
                // Navigate to the web page
                driver.Navigate().GoToUrl(url);

                // Monitor memory usage
                for (int i = 0; i < 1000; i++) // Monitor for 1000 intervals
                {
                    // Simulate some memory usage
                    var data = new Dictionary<string, object>();
                    for (int j = 0; j < 1000; j++)
                    {
                        data.Add(Guid.NewGuid().ToString(), new object());
                    }

                    // Force a garbage collection and wait for pending finalizers to complete
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    // Get total memory used by the application
                    long totalMemoryBytes = GC.GetTotalMemory(forceFullCollection: false);
                    double totalMemoryMegabytes = totalMemoryBytes / 1048576.0; // Convert bytes to megabytes

                    Console.WriteLine($"Memory Usage at interval {i}: {totalMemoryBytes} bytes ({totalMemoryMegabytes:N2} MB)");

                    // Wait a bit before the next interval
                    Thread.Sleep(1000);
                }
            }
            finally
            {
                // Clean up
                driver.Quit();
            }
        }
        
        private void InitializeEdge(string url)
        {
            // Initialize EdgeDriver
            EdgeOptions options = new EdgeOptions();
            IWebDriver driver = new EdgeDriver(options);
            // Cast driver to IJavaScriptExecutor
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            try
            {
                if (url == "") url = baseURL;
                // Navigate to the web page
                driver.Navigate().GoToUrl(url);

                // Monitor memory usage
                for (int i = 0; i < 1000; i++) // Monitor for 1000 intervals
                {
                    // Simulate some memory usage
                    var data = new Dictionary<string, object>();
                    for (int j = 0; j < 1000; j++)
                    {
                        data.Add(Guid.NewGuid().ToString(), new object());
                    }

                    // Force a garbage collection and wait for pending finalizers to complete
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    // Get total memory used by the application
                    long totalMemoryBytes = GC.GetTotalMemory(forceFullCollection: false);
                    double totalMemoryMegabytes = totalMemoryBytes / 1048576.0; // Convert bytes to megabytes

                    Console.WriteLine($"Memory Usage at interval {i}: {totalMemoryBytes} bytes ({totalMemoryMegabytes:N2} MB)");

                    // Wait a bit before the next interval
                    Thread.Sleep(1000);
                }

                // Clean up
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}