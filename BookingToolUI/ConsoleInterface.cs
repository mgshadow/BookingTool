using BookingToolCLI;
using System;

namespace BookingToolUI
{
  public class ConsoleInterface : IUserInterface
  {
    public string ReadLine()
      => Console.ReadLine() ?? "";

    public void WriteLine(string text)
      => Console.WriteLine(text);

    public string ShowMenu()
      => "1 = Book | 2 = Remove | 3 = List | 0 = Exit\n-------------------------------------------";

    public string ConvertStatusToString(BookingStatus booking)
    {
      string result = "";

      if (booking == BookingStatus.confirmed)
        result = "Booking confirmed!";
      if (booking == BookingStatus.waiting)
        result = "You are on the waiting list!";
      if (booking == BookingStatus.duplicate)
        result = "User already exists!";

      return result;
    }

    public void PrintBookings(BookingsList bookings)
    {
      WriteLine("----- Bookings -----");
      int position = 1;

      if (bookings.Confirmed.Count <= 0)
      {
        WriteLine("No booked users.");
      }

      foreach (var booking in bookings.Confirmed)
      {
        WriteLine($"{position++}\t{booking.Id}");
      }

      WriteLine("\n");
      WriteLine("----- Waiting List -----");
      position = 1;
      
      if(bookings.WaitList.Count <= 0)
      {
        WriteLine("No users on waiting list.");
      }
      
      foreach (var booking in bookings.WaitList)
      {
        WriteLine($"{position++}\t{booking.Id}");
      }
    }
  }
}