namespace BookingToolUI
{
  public interface IUserInterface
  {
    string ReadLine();
    void WriteLine(string text);
    string convertStatusToString(BookingStatus status);
  }
}