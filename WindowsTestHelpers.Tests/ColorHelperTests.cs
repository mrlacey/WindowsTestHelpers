using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsTestHelpers.Tests
{
    [TestClass]
    public class ColorHelperTests
    {
        [TestMethod]
        public void Contrast_Black_White()
        {
            var actual = ColorHelper.GetContrastRatio(Color.Black, Color.White);

            Assert.AreEqual(21, actual);
        }

        [TestMethod]
        public void Contrast_White_Black()
        {
            var actual = ColorHelper.GetContrastRatio(Color.White, Color.Black);

            Assert.AreEqual(21, actual);
        }

        [TestMethod]
        public void Contrast_LightGray_Green()
        {
            var actual = ColorHelper.GetContrastRatio(Color.LightGray, Color.Green);

            Assert.AreEqual("3.43", actual.ToString("0.##"));
        }

        [TestMethod]
        public void Contrast_Green_LightGray()
        {
            var actual = ColorHelper.GetContrastRatio(Color.Green, Color.LightGray);

            Assert.AreEqual("3.43", actual.ToString("0.##"));
        }
    }
}
