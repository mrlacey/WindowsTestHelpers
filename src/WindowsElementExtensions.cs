// <copyright file="WindowsElementExtensions.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

using OpenQA.Selenium.Appium.Windows;

namespace WindowsTestHelpers
{
    public static class WindowsElementExtensions
    {
        /// <summary>
        /// Tries to get the named element if it exists.
        /// </summary>
        public static bool TryFindElementByName(this WindowsDriver<WindowsElement> session, string name, out WindowsElement element)
        {
            try
            {
                // FindElementByName will throw if it can't find something matching the name
                element = session.FindElementByName(name);

                return true;
            }
            catch
            {
                element = null;
                return false;
            }
        }

        /// <summary>
        /// Tries to get the named element if it exists.
        /// </summary>
        public static bool TryFindElementByName(this WindowsElement source, string name, out WindowsElement element)
        {
            try
            {
                // FindElementByName will throw if it can't find something matching the name
                element = (WindowsElement)source.FindElementByName(name);

                return true;
            }
            catch
            {
                element = null;
                return false;
            }
        }

        /// <summary>
        /// Tries to get the specified element if it exists.
        /// </summary>
        public static bool TryFindElementByWindowsUIAutomation(this WindowsElement session, string selector, out WindowsElement element)
        {
            try
            {
                // Will throw if it can't find something matching the selector
                element = (WindowsElement)session.FindElementByWindowsUIAutomation(selector);

                return true;
            }
            catch
            {
                element = null;
                return false;
            }
        }

        /// <summary>
        /// Gets the named element if it exists.
        /// </summary>
        public static WindowsElement FindElementByNameIfExists(this WindowsDriver<WindowsElement> session, string name)
        {
            WindowsElement element = null;

            try
            {
                element = session.FindElementByName(name);
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc);
            }

            return element;
        }

        /// <summary>
        /// Click on the element with the specified name.
        /// </summary>
        public static void ClickElement(this WindowsDriver<WindowsElement> session, string name)
        {
            session.FindElementByName(name).Click();
        }

        /// <summary>
        /// Create a screenshot image of the window.
        /// </summary>
        public static void SaveScreenshot(this WindowsDriver<WindowsElement> session, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException(nameof(fileName));
            }

            ImageFormat imgFormat;

            switch (Path.GetExtension(fileName).ToLowerInvariant())
            {
                case ".bmp":
                    imgFormat = ImageFormat.Bmp;
                    break;
                case ".gif":
                    imgFormat = ImageFormat.Gif;
                    break;
                case ".jpg":
                case ".jpeg":
                    imgFormat = ImageFormat.Jpeg;
                    break;
                case ".png":
                    imgFormat = ImageFormat.Png;
                    break;
                case ".tif":
                case ".tiff":
                    imgFormat = ImageFormat.Tiff;
                    break;
                default:
                    throw new ArgumentException("Unsupported file extension.", nameof(fileName));
            }

            var screenshot = session.GetScreenshot();
            screenshot.SaveAsFile(fileName, imgFormat);
        }
    }
}
