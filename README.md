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

- `ExecuteScript()`

## StringAssert

- `AreEqual()`

## SystemSettingsHelper

- `TurnOffHighContrastAsync()`
- `SwitchToHighContrastNumber1Async()`
- `SwitchToHighContrastNumber2Async()`
- `SwitchToHighContrastBlackAsync()`
- `SwitchToHighContrastWhiteAsync()`

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
