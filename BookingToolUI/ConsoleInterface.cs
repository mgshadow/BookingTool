using System;

namespace BookingToolUI
{
  public class ConsoleInterface : IUserInterface
  {
    public string ReadLine()
      => Console.ReadLine() ?? "";

    public void WriteLine(string text)
      => Console.WriteLine(text);

    public string convertStatusToString(BookingStatus booking)
    {
      string temp;
      if (booking.status == BookingStatus.confirmed)
        temp = "Booking confirmed!";
      if (booking.status == BookingStatus.waiting)
        temp = "You are on the waiting list!";
      if (booking.status == BookingStatus.duplicate)
        temp = "User already exists!";
      return temp;
    }
  }
}