using System;

namespace BookingToolUI
{
  public class ConsoleInterface : IUserInterface
  {
    public string ReadLine()
      => Console.ReadLine() ?? "";

    public void WriteLine(string text)
      => Console.WriteLine(text);
  }
}