// <copyright file="WtsBasedApp.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using OpenQA.Selenium.Appium.Windows;

namespace WindowsTestHelpers
{
    public static class WtsBasedApp
    {
        /// <summary>
        /// Repeatedly click on the Back button while it is enabled.
        /// </summary>
        public static void GoAllTheWayBackThroughBackStack(WindowsDriver<WindowsElement> appSession)
        {
            WindowsElement backButton = appSession.FindElementByNameIfExists("Back");

            while (backButton != null)
            {
                backButton.Click();

                backButton = appSession.FindElementByNameIfExists("Back");
            }
        }

        /// <summary>
        /// Navigate to the Settings page and select the Light theme.
        /// </summary>
        public static bool SetAppToLightTheme(WindowsDriver<WindowsElement> appSession)
        {
            appSession.FindElementByName("Settings").Click();

            // Toggle name is current theme
            var darkToggle = appSession.FindElementByNameIfExists("Dark");

            if (darkToggle != null)
            {
                darkToggle.Click();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Navigate to the Settings page and select the Dark theme.
        /// </summary>
        public static bool SetAppToDarkTheme(WindowsDriver<WindowsElement> appSession)
        {
            appSession.FindElementByName("Settings").Click();

            // Toggle name is current theme
            var lightToggle = appSession.FindElementByNameIfExists("Light");

            if (lightToggle != null)
            {
                lightToggle.Click();
                return true;
            }

            return false;
        }
    }
}
