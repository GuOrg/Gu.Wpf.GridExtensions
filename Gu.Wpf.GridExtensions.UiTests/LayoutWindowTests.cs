namespace Gu.Wpf.GridExtensions.UiTests
{
    using Gu.Wpf.UiAutomation;
    using NUnit.Framework;

    public class LayoutWindowTests
    {
        private const string WindowName = "LayoutWindow";

        [OneTimeSetUp]
        public void OnetimeSetup()
        {
            using (var app = Application.AttachOrLaunch("Gu.Wpf.GridExtensions.Demo.exe", WindowName))
            {
                app.MainWindow.MoveTo(0, 0);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched("Gu.Wpf.GridExtensions.Demo.exe");
        }

        [TestCase("0 0", "7;7;200;100")]
        [TestCase("0 1", "207;7;100;100")]
        [TestCase("1 0", "7;107;200;100")]
        [TestCase("1 1", "207;107;100;100")]
        [TestCase("2 0", "7;207;200;50")]
        [TestCase("2 1", "207;207;100;50")]
        public void Bounds(string header, string bounds)
        {
            using (var app = Application.AttachOrLaunch("Gu.Wpf.GridExtensions.Demo.exe", WindowName))
            {
                var window = app.MainWindow;
                var box = window.FindGroupBox(header);
                Assert.AreEqual(bounds, box.Bounds.ToString());
            }
        }
    }
}
