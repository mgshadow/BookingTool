using BookingToolCLI;

namespace BookingToolUI
{
  public interface IUserInterface
  {
    string ReadLine();
    void WriteLine(string text);
    string ConvertStatusToString(BookingStatus status);
    string ShowMenu();
    void PrintBookings(BookingsList bookings);
  }
}