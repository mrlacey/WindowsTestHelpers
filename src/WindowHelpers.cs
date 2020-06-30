// <copyright file="WindowHelpers.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace WindowsTestHelpers
{
    // This is based, in part, on https://stackoverflow.com/a/35018042/1755
    public class WindowHelpers
    {
        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            Maximize = 3,
            ShowNormalNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActivate = 7,
            ShowNoActivate = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimized = 11,
        }

        public static void BringVisualStudioToFront(string projectName)
        {
            BringVisualStudioToFrontInternal(projectName);
        }

        public static void BringWindowToFront(string windowName)
        {
            BringWindowToFrontInternal(windowName);
        }

        public static void TryFlashVisualStudio(string projectName)
        {
            var hndl = BringVisualStudioToFrontInternal(projectName);

            FlashWindow(hndl, true);
        }

        public static void TryFlashWindow(string windowName)
        {
            var hndl = BringWindowToFrontInternal(windowName);

            FlashWindow(hndl, true);
        }

        private static IntPtr BringVisualStudioToFrontInternal(string projectName)
        {
            var isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

            var name = isAdmin ? $"{projectName} - Microsoft Visual Studio (Administrator)"
                               : $"{projectName} - Microsoft Visual Studio";

            return BringWindowToFrontInternal(name);
        }

        private static IntPtr BringWindowToFrontInternal(string windowName)
        {
            IntPtr wdwIntPtr = FindWindow(null, windowName);

            var placement = default(Windowplacement);
            GetWindowPlacement(wdwIntPtr, ref placement);

            // Check if window is minimized
            if (placement.showCmd == 2)
            {
                ShowWindow(wdwIntPtr, ShowWindowEnum.Restore);
            }

            SetForegroundWindow(wdwIntPtr);

            return wdwIntPtr;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref Windowplacement lpwndpl);

        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        private struct Windowplacement
        {
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter
        }
    }
}
