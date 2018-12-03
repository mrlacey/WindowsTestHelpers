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

        public async Task TurnOffHighContrastAsync()
        {
            await this.SetHighContrastAsync("None");
        }

        public async Task SwitchToHighContrastNumber1Async()
        {
            await this.SetHighContrastAsync("High Contrast #1");
        }

        public async Task SwitchToHighContrastNumber2Async()
        {
            await this.SetHighContrastAsync("High Contrast #2");
        }

        public async Task SwitchToHighContrastBlackAsync()
        {
            await this.SetHighContrastAsync("High Contrast Black");
        }

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

            var dropDown = settingsWindow.FindElementByAccessibilityId("SystemSettings_Accessibility_HighContrast_HCThemesComboBox");

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

            settingsWindow.FindElementByName("Close Settings").Click();
        }
    }
}
