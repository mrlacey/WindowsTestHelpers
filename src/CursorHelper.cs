// <copyright file="CursorHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System.Runtime.InteropServices;

namespace WindowsTestHelpers
{
    public static class CursorHelper
    {
        public static void MoveToTopLeftOfScreen()
        {
            SetCursorPos(0, 0);
        }

        [DllImport("User32.dll")]
#pragma warning disable SA1313 // Parameter names must begin with lower-case letter
        private static extern bool SetCursorPos(int X, int Y);
#pragma warning restore SA1313 // Parameter names must begin with lower-case letter
    }
}
