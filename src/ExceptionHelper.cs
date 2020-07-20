// <copyright file="ExceptionHelper.cs" company="Matt Lacey">
// Copyright © Matt Lacey. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the solution root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsTestHelpers
{
    public static class ExceptionHelper
    {
        public static void RetryOn<TException>(Action whatToRetry, int maxRetryAttempts = 1)
            where TException : Exception
        {
            var attemptsMade = 0;

            var keepRetrying = true;

            while (keepRetrying)
            {
                try
                {
                    whatToRetry();

                    keepRetrying = false;
                }
                catch (Exception exc)
                {
                    if (exc is TException)
                    {
                        if (++attemptsMade > maxRetryAttempts)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}
