// <copyright file="ListOfStringAssert.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsTestHelpers
{
    public static class ListOfStringAssert
    {
        public static void AssertAreEqualIgnoringOrder(string[] expected, string[] actual, bool caseSensitive = true, string message = "")
        {
            AssertAreEqualIgnoringOrder(expected.ToList(), actual.ToList(), caseSensitive, message);
        }

        public static void AssertAreEqualIgnoringOrder(List<string> expected, List<string> actual, bool caseSensitive = true, string message = "")
        {
            if (actual == null)
            {
                throw new ArgumentNullException(nameof(actual));
            }

            if (expected == null)
            {
                throw new ArgumentNullException(nameof(expected));
            }

            if (expected.Count == 0)
            {
                Assert.AreEqual(
                    expected.Count,
                    actual.Count,
                    $"Expected was empty but actual contained {actual.Count} items.{Environment.NewLine}{message}");
            }

            var errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                if (expected.Count() != actual.Count())
                {
                    errorMessage = $"Number of items differs. Expected:{expected.Count} Actual:{actual.Count}";
                }
                else
                {
                    var sortedExpected = expected.OrderBy(e => e).ToList();
                    var sortedActual = actual.OrderBy(a => a).ToList();

                    for (int i = 0; i < sortedExpected.Count(); i++)
                    {
                        var expectedComparisonValue = caseSensitive ? sortedExpected[i] : sortedExpected[i].ToUpperInvariant();
                        var actualComparisonValue = caseSensitive ? sortedActual[i] : sortedActual[i].ToUpperInvariant();

                        if (expectedComparisonValue != actualComparisonValue)
                        {
                            errorMessage = $"Actual is missing an instance of '{sortedExpected[i]}'.";
                            break;
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                Assert.Fail($"{Environment.NewLine}{errorMessage}{Environment.NewLine}{message}");
            }
        }
    }
}
