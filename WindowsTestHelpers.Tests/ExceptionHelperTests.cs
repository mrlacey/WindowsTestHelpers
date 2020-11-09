using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsTestHelpers.Tests
{
    [TestClass]
    public class ExceptionHelperTests
    {
        [TestMethod]
        public void WhenNoMaxRetryAttemptsSpecified()
        {
            var callCount = 0;

            try
            {
                ExceptionHelper.RetryOn<Exception>(
                    () =>
                    {
                        callCount++;
                        throw new Exception();
                    });
            }
            catch
            {
                // Do nothing. Want exceptions to not end the test
            }

            Assert.AreEqual(2, callCount);
        }

        [TestMethod]
        public void NoRetryWhenNoMaxRetryAttemptsIsZero()
        {
            var callCount = 0;

            try
            {
                ExceptionHelper.RetryOn<Exception>(
                    () =>
                    {
                        callCount++;
                        throw new Exception();
                    },
                    maxRetryAttempts: 0);
            }
            catch
            {
                // Do nothing. Want exceptions to not end the test
            }

            Assert.AreEqual(1, callCount);
        }

        [TestMethod]
        public void RetriesMatchWhatIsSpecified()
        {
            var callCount = 0;

            try
            {
                ExceptionHelper.RetryOn<Exception>(
                    () =>
                    {
                        callCount++;
                        throw new Exception();
                    },
                    maxRetryAttempts: 5);
            }
            catch
            {
                // Do nothing. Want exceptions to not end the test
            }

            Assert.AreEqual(6, callCount);
        }

        [TestMethod]
        public void RetryOnlyOnSpecifiedTyped()
        {
            var callCount = 0;

            try
            {
                ExceptionHelper.RetryOn<NullReferenceException>(
                    () =>
                    {
                        callCount++;
                        throw new ApplicationException();
                    });
            }
            catch
            {
                // Do nothing. Want exceptions to not end the test
            }

            Assert.AreEqual(1, callCount);
        }

        [TestMethod]
        public void RetryOnParentOfSpecifiedTyped()
        {
            var callCount = 0;

            try
            {
                ExceptionHelper.RetryOn<Exception>(
                    () =>
                    {
                        callCount++;
                        throw new NullReferenceException();
                    });
            }
            catch
            {
                // Do nothing. Want exceptions to not end the test
            }

            // This should retry as all exceptions inherit from Exception
            Assert.AreEqual(2, callCount);
        }

        [TestMethod]
        public void DontRetryOnGeneralErrorIfSpecificOneSpecified()
        {
            var callCount = 0;

            try
            {
                ExceptionHelper.RetryOn<NullReferenceException>(
                    () =>
                    {
                        callCount++;
                        throw new Exception();
                    });
            }
            catch
            {
                // Do nothing. Want exceptions to not end the test
            }

            Assert.AreEqual(1, callCount);
        }

        [TestMethod]
        public void DontRetryIfNoException()
        {
            var callCount = 0;

            try
            {
                ExceptionHelper.RetryOn<Exception>(
                    () =>
                    {
                        callCount++;
                    });
            }
            catch
            {
                // Do nothing. Want exceptions to nt end the test
            }

            Assert.AreEqual(1, callCount);
        }

        [TestMethod]
        public void StopRetryingIfNoExceptionEncountered()
        {
            var callCount = 0;

            try
            {
                ExceptionHelper.RetryOn<Exception>(
                    () =>
                    {
                        callCount++;

                        if (callCount < 3)
                        {
                            throw new Exception();
                        }
                    },
                    maxRetryAttempts: 5);
            }
            catch
            {
                // Do nothing. Want exceptions to nt end the test
            }

            Assert.AreEqual(3, callCount);
        }
    }
}
