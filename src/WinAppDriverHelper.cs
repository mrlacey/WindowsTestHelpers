﻿// <copyright file="WinAppDriverHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace WindowsTestHelpers
{
    public static class WinAppDriverHelper
    {
        /// <summary>
        /// Asserts that the WinAppDriver executable can be found on disk.
        /// </summary>
        public static void CheckIsInstalled(string pathToExe = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe")
        {
            Assert.IsTrue(
                File.Exists(pathToExe),
                "WinAppDriver is not installed. Download from https://github.com/Microsoft/WinAppDriver/releases");
        }

        /// <summary>
        /// Start WinAppDriver.exe if not already running.
        /// </summary>
        public static void StartIfNotRunning(string pathToExe = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe")
        {
            var script = @"
$wad = Get-Process WinAppDriver -ErrorAction SilentlyContinue

if ($wad -eq $Null)
{
    Start-Process """ + pathToExe + @"""
}";

            PowerShellHelper.ExecuteScript(script);
        }

        /// <summary>
        /// Stop the WinAppDriver.exe process, if running.
        /// </summary>
        public static void StopIfRunning()
        {
            var script = @"
$wad = Get-Process WinAppDriver -ErrorAction SilentlyContinue

if ($wad -ne $null)
{
    $wad.CloseMainWindow()
}";

            PowerShellHelper.ExecuteScript(script);
        }

        /// <summary>
        /// Start the specified executable.
        /// </summary>
        public static WindowsDriver<WindowsElement> LaunchExe(string exeFilePath, string appArguments = "", string appWorkingDir = "", string winAppDriverUrl = "http://127.0.0.1:4723")
        {
            if (string.IsNullOrWhiteSpace(exeFilePath))
            {
                throw new ArgumentException(nameof(exeFilePath));
            }

            if (!File.Exists(exeFilePath))
            {
                throw new ArgumentException("Exe does not exist.", nameof(exeFilePath));
            }

            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", exeFilePath);

            if (!string.IsNullOrWhiteSpace(appArguments))
            {
                appCapabilities.SetCapability("appArguments", appArguments);
            }

            if (string.IsNullOrWhiteSpace(appWorkingDir))
            {
                appWorkingDir = Path.GetDirectoryName(exeFilePath);
            }

            appCapabilities.SetCapability("appWorkingDir", appWorkingDir);

            return new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), appCapabilities);
        }

        /// <summary>
        /// Start the specified APPX package.
        /// </summary>
        public static WindowsDriver<WindowsElement> LaunchAppx(string installedAppxPackageFamilyName, string winAppDriverUrl = "http://127.0.0.1:4723")
        {
            var app = installedAppxPackageFamilyName;

            // To launch app we need the path to the app object.
            // Tis is normally the PFN followed by "!App" but may be different due to a differently configured launch object
            if (!app.Contains("!"))
            {
                app += "!App";
            }

            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", app);
            appCapabilities.SetCapability("deviceName", "WindowsPC");

            var appSession = new WindowsDriver<WindowsElement>(new Uri(winAppDriverUrl), appCapabilities);
            appSession.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));

            return appSession;
        }
    }
}
