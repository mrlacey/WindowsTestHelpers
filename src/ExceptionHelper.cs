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
        /// <summary>
        /// Enables automatic retrying of the action if the specified Exception is thrown.
        /// </summary>
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

        public static async Task RetryOnAsync<TException>(Func<Task> whatToRetry, int maxRetryAttempts = 1)
            where TException : Exception
        {
            var attemptsMade = 0;

            var keepRetrying = true;

            while (keepRetrying)
            {
                try
                {
                    await whatToRetry();

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
