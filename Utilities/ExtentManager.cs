using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace PlaywrightTests.Utilities
{
    public class ExtentManager
    {
        private static ExtentReports? _extent;
        private static ExtentTest? _test;

        public static ExtentReports GetExtent()
        {
            if (_extent == null)
            {
                var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "PlaywrightTestReport.html");
                Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);

                var htmlReporter = new ExtentSparkReporter(reportPath);
                htmlReporter.Config.DocumentTitle = "Playwright Test Report";
                htmlReporter.Config.ReportName = "SauceDemo Playwright Automation";
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
                _extent.AddSystemInfo("Framework", "Playwright + NUnit");
                _extent.AddSystemInfo("Browser", "Chromium");
                _extent.AddSystemInfo("Language", "C# (.NET 10)");
                _extent.AddSystemInfo("Application", "SauceDemo");
                _extent.AddSystemInfo("Environment", "QA");
            }
            return _extent;
        }

        public static ExtentTest CreateTest(string testName, string category = "")
        {
            _test = GetExtent().CreateTest(testName);
            if (!string.IsNullOrEmpty(category))
            {
                _test.AssignCategory(category);
            }
            return _test;
        }

        public static ExtentTest GetTest()
        {
            return _test!;
        }

        public static void FlushReport()
        {
            _extent?.Flush();
        }
    }
}