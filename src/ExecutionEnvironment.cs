// <copyright file="ExecutionEnvironment.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsTestHelpers
{
    public static class ExecutionEnvironment
    {
        /// <summary>
        /// Asserts that the test is running with Administrator privileges.
        /// </summary>
        public static void CheckRunningAsAdmin()
        {
            Assert.IsTrue(
                new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator),
                "Must be running as Administrator to execute these tests.");
        }
    }
}
