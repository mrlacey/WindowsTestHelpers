// <copyright file="VirtualKeyboard.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;

namespace WindowsTestHelpers
{
    public static class VirtualKeyboard
    {
        private const int KeyeventfExtendedkey = 1;
        private const int KeyeventfKeyup = 2;

        // Values from System.Windows.Forms.Keys
        private const byte WindowsKey = 91;
        private const byte LetterM = 77;
        private const byte Down = 40;

        /// <summary>
        /// Minimizes all windows on the desktop.
        /// </summary>
        public static void MinimizeAllWindows()
        {
            KeyDown(WindowsKey);
            KeyDown(LetterM);
            KeyUp(LetterM);
            KeyUp(WindowsKey);
        }

        /// <summary>
        /// Restores the current window if maximized.
        /// </summary>
        public static void RestoreMaximizedWindow()
        {
            KeyDown(WindowsKey);
            KeyDown(Down);
            KeyUp(Down);
            KeyUp(WindowsKey);
        }

        /// <summary>
        /// Send the Windows message for a key being pressed down.
        /// </summary>
        public static void KeyDown(byte vKey)
        {
            keybd_event(vKey, 0, KeyeventfExtendedkey, 0);
        }

        /// <summary>
        /// Send the Windows message for a key being released.
        /// </summary>
        public static void KeyUp(byte vKey)
        {
            keybd_event(vKey, 0, KeyeventfExtendedkey | KeyeventfKeyup, 0);
        }

        [DllImport("user32.dll")]
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable IDE1006 // Naming Styles
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore SA1300 // Element must begin with upper-case letter
    }
}
