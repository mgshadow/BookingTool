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
     - currently Waiting List and Booking List are implemented as a `List<BookingEntry>`, using a `Queue` class would be more straightforward because of FiFo principle
- Implementation of `GetBookings()` is straightforward
- Tests for the implementation are successful

## Implemented the following API function:
 - MakeBooking
 - RemoveBooking
 - GetBookings

## Improvements for the next week:
 - BookingByID function