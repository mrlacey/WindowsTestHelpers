// <copyright file="PowerShellHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace WindowsTestHelpers
{
    public static class PowerShellHelper
    {
        /// <summary>
        /// Execute a powershell script.
        /// Some PowerShell scripts require admin permission. If needed call `ExecutionEnvironment.CheckRunningAsAdmin()` first.
        /// </summary>
        /// <param name="script">The script to run.</param>
        /// <param name="outputOnError">If the method should return the script output even if there's an error.</param>
        /// <returns>The ouptut from the script.</returns>
        public static Collection<PSObject> ExecuteScript(string script, bool outputOnError = false)
        {
            using (var ps = PowerShell.Create())
            {
                ps.AddScript(script);

                Collection<PSObject> psOutput = ps.Invoke();

                if (ps.Streams.Error.Count > 0)
                {
                    foreach (var errorRecord in ps.Streams.Error)
                    {
                        Debug.WriteLine(errorRecord.ToString());
                    }

                    // Some things (such as failing test execution) report an error but we still want the full output
                    if (!outputOnError)
                    {
                        throw new PSInvalidOperationException(ps.Streams.Error.First().ToString());
                    }
                }

                return psOutput;
            }
        }
    }
}
