# BookingTool

## How to Start the Program
@Team console-application-> pease write this

## How to Run Checks
- Run all Unit Tests in the UnitTests.csproj or via the TestExplorer

## What ist unfinished
- implementation of console application -> @team console-applilcation, please remove this line after implementation

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

## Implemented the following API function:
 - MakeBooking
 - RemoveBooking
 - GetBookings

## Improvements for the next week:
 - BookingByID function