using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightTests.Utilities;
using AventStack.ExtentReports;
using System.Linq;

namespace PlaywrightTests.Support
{
    public class TestBase : PageTest
    {
        protected ExtentTest? Test;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ExtentManager.GetExtent();
        }

        [SetUp]
        public void SetupTest()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var categories = TestContext.CurrentContext.Test.Properties["Category"];
            
            // Fixed: Cast to string enumerable and check count properly
            var categoryList = categories.Cast<string>().ToList();
            var category = categoryList.Any() ? string.Join(", ", categoryList) : "";
            
            Test = ExtentManager.CreateTest(testName, category);
            Test.Info("Test started");
        }

        [TearDown]
        public async Task TeardownTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Test?.Fail($"Test Failed: {TestContext.CurrentContext.Result.Message}");
                
                // Take screenshot on failure
                try
                {
                    var screenshot = await Page.ScreenshotAsync();
                    var screenshotPath = Path.Combine("Reports", "Screenshots", $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath)!);
                    File.WriteAllBytes(screenshotPath, screenshot);
                    
                    Test?.AddScreenCaptureFromPath(screenshotPath);
                    Test?.Info("Screenshot captured");
                }
                catch (Exception ex)
                {
                    Test?.Warning($"Failed to capture screenshot: {ex.Message}");
                }
            }
            else
            {
                Test?.Pass("Test passed successfully");
            }
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            ExtentManager.FlushReport();
        }
    }
}