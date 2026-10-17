# BookingTool

## How to Start the Program
- Compile the solution and run the `BookingToolUI.exe`

## How to Run Checks
- Run all Unit Tests in the UnitTests.csproj or via the TestExplorer

## Improvements for the next week:
- function to remove booking
  - add tests to verify removal of bookings
- create a general Equatable class instead of making each data model class itself equatable

## Review group 1 from group 2
 - Test for projects working correctly, everyone failed.
 - UnitTests.cs line 26,43,61,146,127 corrected. Check the ID from the object
      Assert.AreEqual("alex", result.Confirmed[0].Id);
 - Added testcases for the RemoveBooking function.
 - UnitTests.cs line 147 modified
      Assert.AreEqual("Alex", result.Confirmed[1].Id);
 - For the Testcase OneSequenceTest "Assert" to "CollectionAssert" changed.

## Review group 2 from group 3
- Implementation of `MakeBooking(string id)` is correct
- Implementation of `RemoveBooking(string id)`:
     - at the moment, by removing a booking, the first element on the waiting list is added at the end of the current bookings
     - another design choice could be to replace the removed booking by the first element on the waiting list. in this case, the code has to be changed to: `confirmed.Insert(confirmedIndex, waitList[0]); waitList.RemoveAt(0);`
- Implementation of `GetBookings()` is straightforward
- Tests for the implementation are successful
- Improved readability of implemented features by adding clear brackets for if statements

## Review Group 3 from Group 
- In the `PrintBookings` function, removed the position counter and implemented the selection with a value/index tuple instead, since the `position` variable is not needed outside the loop.
- Refactored the `ConvertStatusToString` function to use a `switch`; an error message is now raised when an invalid or `null` status is passed.
- Console Commands aren't anymore defined multiple times across `Program.cs` and `ConsoleInterface.cs` but rather properties of the IUserInterface.

## Implemented the following API function:
 - MakeBooking
 - RemoveBooking
 - GetBookings

## Improvements for the next week:
 - BookingByID function

## Unfinished
- How to test cleanly TestUIs (Program.cs is currently not tested.)