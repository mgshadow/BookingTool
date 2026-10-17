using BookingToolCLI;
using System.Collections.Generic;

namespace BookingToolUI.Tests
{
    public class FakeConsoleInterface : IUserInterface
    {
        public string Input { get; }
        public List<string> Outputs { get; }

        public string BookCommand => realUserInterface.BookCommand;

        public string RemoveCommand => realUserInterface.RemoveCommand;

        public string ListCommand => realUserInterface.ListCommand;

        public string ExitCommand => realUserInterface.ExitCommand;

        private IUserInterface realUserInterface;

        public FakeConsoleInterface(string input = "")
        {
            Input = input;
            Outputs = new List<string>();

            realUserInterface = new ConsoleInterface();
        }

        public string ReadLine()
        {
            return Input;
        }

        public void WriteLine(string text)
        {
            Outputs.Add(text);
        }

        public string ConvertStatusToString(BookingStatus booking)
        {
            return realUserInterface.ConvertStatusToString(booking);
        }

        public string ShowMenu()
        {
            return realUserInterface.ShowMenu();
        }

        public void PrintBookings(BookingsList bookings)
        {
            realUserInterface.PrintBookings(bookings);
        }
    }
}
