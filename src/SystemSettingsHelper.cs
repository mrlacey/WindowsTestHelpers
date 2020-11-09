// <copyright file="SystemSettingsHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace WindowsTestHelpers
{
    public class SystemSettingsHelper
    {
        public SystemSettingsHelper(string winAppDriverUrl = "http://127.0.0.1:4723")
        {
            this.WindowsApplicationDriverUrl = winAppDriverUrl;
        }

        public string WindowsApplicationDriverUrl { get; private set; }

        /// <summary>
        /// Uses WinApDriver to automate turning high contrast mode off on the machine.
        /// </summary>
        public async Task TurnOffHighContrastAsync()
        {
            await this.SetHighContrastAsync("None");
        }

        /// <summary>
        /// Uses WinApDriver to automate enabling high contrast mode #1 on the machine.
        /// </summary>
        public async Task SwitchToHighContrastNumber1Async()
        {
            await this.SetHighContrastAsync("High Contrast #1");
        }

        /// <summary>
        /// Uses WinApDriver to automate enabling high contrast mode #2 on the machine.
        /// </summary>
        public async Task SwitchToHighContrastNumber2Async()
        {
            await this.SetHighContrastAsync("High Contrast #2");
        }

        /// <summary>
        /// Uses WinApDriver to automate enabling high contrast black mode on the machine.
        /// </summary>
        public async Task SwitchToHighContrastBlackAsync()
        {
            await this.SetHighContrastAsync("High Contrast Black");
        }

        /// <summary>
        /// Uses WinApDriver to automate enabling high contrast white mode on the machine.
        /// </summary>
        public async Task SwitchToHighContrastWhiteAsync()
        {
            await this.SetHighContrastAsync("High Contrast White");
        }

        private async Task SetHighContrastAsync(string highContrastMode)
        {
            Process.Start("ms-settings:easeofaccess-highcontrast");

            var desktopCapabilities = new DesiredCapabilities();
            desktopCapabilities.SetCapability("app", "Root");

            var desktopSession = new WindowsDriver<WindowsElement>(new Uri(this.WindowsApplicationDriverUrl), desktopCapabilities);

            var settingsWindow = desktopSession.FindElementByName("Settings");

            WindowsElement themeSelector;

            // 1803 introduced changes to the structure of the settings screen.
            // See if settings page has the new way of enabling HighContrast
            if (settingsWindow.TryFindElementByName("High-contrast theme", out themeSelector))
            {
                settingsWindow.TryFindElementByName("Turn on high contrast", out var toggle);

                if (highContrastMode == "None")
                {
                    if (themeSelector.Enabled)
                    {
                        toggle.Click();

                        // Allow changes to be applied
                        await Task.Delay(15000);
                    }
                }
                else
                {
                    if (!themeSelector.Enabled)
                    {
                        toggle.Click();
                        await Task.Delay(5000); // Allow for settings UI to update after enabling HC
                    }

                    themeSelector.Click();
                    await Task.Delay(1000); // Allow for UI to update & list to load

                    var listItems = settingsWindow.FindElementsByClassName("ComboBoxItem");

                    foreach (var item in listItems)
                    {
                        if (item.Text == highContrastMode)
                        {
                            item.Click();
                            break;
                        }
                    }

                    settingsWindow.FindElementByName("Apply").Click();

                    // Allow changes to be applied
                    await Task.Delay(15000);
                }
            }
            else
            {
                // Rely on old settings dialog.
                var dropDown =
                    settingsWindow.FindElementByAccessibilityId(
                        "SystemSettings_Accessibility_HighContrast_HCThemesComboBox");

                if (dropDown.Text != highContrastMode)
                {
                    dropDown.Click();

                    var listItems = settingsWindow.FindElementsByClassName("ComboBoxItem");

                    foreach (var item in listItems)
                    {
                        if (item.Text == highContrastMode)
                        {
                            item.Click();
                            break;
                        }
                    }

                    settingsWindow.FindElementByName("Apply").Click();

                    // TODO: Need to find a better solution than pausing this long
                    await Task.Delay(30000);
                }
            }

            settingsWindow.FindElementByName("Close Settings").Click();
        }
    }
}
