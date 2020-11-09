// <copyright file="ColorHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Drawing;

namespace WindowsTestHelpers
{
    public static class ColorHelper
    {
        // Formula from https://www.w3.org/TR/2008/REC-WCAG20-20081211/#relativeluminancedef
        public static double GetLuminance(Color color)
        {
            double ConvertComponent(byte rgb)
            {
                var sRGB = rgb / 255.0;

                return sRGB < .03928 ? sRGB / 12.92 : Math.Pow((sRGB + .055) / 1.055, 2.4);
            }

            var r = ConvertComponent(color.R);
            var g = ConvertComponent(color.G);
            var b = ConvertComponent(color.B);

            return (.2126 * r) + (0.7152 * g) + (0.0722 * b);
        }

        public static double GetContrastRatio(Color color1, Color color2)
        {
            var lum1 = GetLuminance(color1);
            var lum2 = GetLuminance(color2);

            var ratio = (lum1 + 0.05) / (lum2 + 0.05);

            if (lum2 > lum1)
            {
                ratio = 1 / ratio;
            }

            return ratio;
        }
    }
}
