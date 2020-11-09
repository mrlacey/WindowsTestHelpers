# WindowsTestHelpers

The following functionality is included 

## AssertExtensions

* `ComplexStringsAreEqual()` - Compares strings and includes details about the differences if they don't match.

## CognitiveServicesHelpers

- `GetTextFromImageAsync()` - Extract images from the specified image file.

## CursorHelper

- `MoveToTopLeftOfScreen()` - Move the cursor to the top left of the screen so it isn't effecting any content on the UI.

## ExceptionHelper

- `RetryOn<TException>()` - Enables automatic retrying of the action if the specified Exception is thrown.

## ExecutionEnvironment

- `CheckRunningAsAdmin()` - Asserts that the test is running with Administrator privileges.

## ImageComparer

- `PercentageDifferent()` - Calculates the percentage differrence between the pixels of two images.
- `GetDifferenceImage()` - Generates a version of the first image highlighting where differences exist between it and the second.
- `GetDifferences()` - Get the location of differences between scaled versions of the provided images.
- `GetGrayScaleVersion()` - Returns a gray-scale version of the provided image.
- `Resize()` - Returns a version of hte image with the specified height and width.

## ListOfStringAssert

- `AssertAreEqualIgnoringOrder()` - Asserts that the contents of the provided lists are the same if order is ignored.

## PowerShellHelper

- `ExecuteScript()` - Execute a powershell script.

## StringAssert

- `AreEqual()` - Provides more detailed output when compared strings are not equal.

## SystemSettingsHelper

- `TurnOffHighContrastAsync()` - Uses WinApDriver to automate turning high contrast mode off on the machine.
- `SwitchToHighContrastNumber1Async()` - Uses WinApDriver to automate enabling high contrast mode #1 on the machine.
- `SwitchToHighContrastNumber2Async()` - Uses WinApDriver to automate enabling high contrast mode #2 on the machine.
- `SwitchToHighContrastBlackAsync()` - Uses WinApDriver to automate enabling high contrast black mode on the machine.
- `SwitchToHighContrastWhiteAsync()` - Uses WinApDriver to automate enabling high contrast white mode on the machine.

## VirtualKeyboard

- `MinimizeAllWindows()` - Minimizes all windows on the desktop.
- `RestoreMaximizedWindow()` - Restores the current window if maximized.
- `KeyDown()` - Send the Windows message for a key being pressed down.
- `KeyUp()` - Send the Windows message for a key being released.

## WinAppDriverHelper

- `CheckIsInstalled()` - Asserts that the WinAppDriver executable can be found on disk.
- `StartIfNotRunning()` - Start WinAppDriver.exe if not already running.
- `StopIfRunning()` - Stop the WinAppDriver.exe process, if running.
- `LaunchExe()` - Start the specified executable.
- `LaunchAppx()` - Start the specified APPX package.

## WindowHelpers

- `BringVisualStudioToFront()` - Makes Visual Studio the active foreground window on the desktop.
- `BringWindowToFront()` -  Makes the specified app the active foreground window on the desktop.
- `TryFlashVisualStudio()` - Flashes Visual Studio's task bar icon.
- `TryFlashWindow()` - Flashes the specified window's task bar icon.

## WindowsElementExtensions

- `TryFindElementByName()` - Tries to get the named element if it exists.
- `TryFindElementByWindowsUIAutomation()` - Tries to get the specified element if it exists..
- `FindElementByNameIfExists()` - Gets the named element if it exists.
- `ClickElement()` - Click on the element with the specified name.
- `SaveScreenshot()` - Create a screenshot image of the window.

## WtsBasedApp (Windows Template Studio base UWP app)

- `GoAllTheWayBackThroughBackStack()` - Repeatedly click on the Back button while it is enabled.
- `SetAppToLightTheme()` - Navigate to the Settings page and select the Light theme.
- `SetAppToDarkTheme()` - Navigate to the Settings page and select the Dark theme.
