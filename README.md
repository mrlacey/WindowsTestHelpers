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

- `MinimizeAllWindows()`
- `RestoreMaximizedWindow()`
- `KeyDown()`
- `KeyUp()`

## WinAppDriverHelper

- `CheckIsInstalled()`
- `StartIfNotRunning()`
- `StopIfRunning()`
- `LaunchExe()`
- `LaunchAppx()`

## WindowHelpers

- `BringVisualStudioToFront()`
- `BringWindowToFront()`
- `TryFlashVisualStudio()`
- `TryFlashWindow()`

## WindowsElementExtensions

- `TryFindElementByName()`
- `TryFindElementByWindowsUIAutomation()`
- `FindElementByNameIfExists()`
- `ClickElement()`
- `SaveScreenshot()`

## WtsBasedApp

- `GoAllTheWayBackThroughBackStack()`
- `SetAppToLightTheme()`
- `SetAppToDarkTheme()`
