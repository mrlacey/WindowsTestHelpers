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

- `PercentageDifferent()`
- `GetDifferenceImage()`
- `GetDifferences()`
- `GetGrayScaleVersion()`
- `Resize()`

## ListOfStringAssert

- `AssertAreEqualIgnoringOrder()`

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
