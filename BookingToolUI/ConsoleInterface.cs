using BookingToolCLI;
using System;
using System.Linq;

namespace BookingToolUI
{
    public class ConsoleInterface : IUserInterface
    {
        public string BookCommand => "1";

        public string RemoveCommand => "2";

        public string ListCommand => "8";

        public string ExitCommand => "0";

        public string ReadLine()
          => Console.ReadLine() ?? "";

        public void WriteLine(string text)
          => Console.WriteLine(text);

        public string ShowMenu()
          => $"{BookCommand} = Book | {RemoveCommand} = Remove | {ListCommand} = List | {ExitCommand} = Exit\n-------------------------------------------";

        public string ConvertStatusToString(BookingStatus booking)
        {
            switch (booking)
            {
                case BookingStatus.Confirmed:
                    return "Booking confirmed!";
                case BookingStatus.Waiting:
                    return "You are on the waiting list!";
                case BookingStatus.Duplicate:
                    return "User already exists!";
                default:
                    throw new InvalidOperationException();
            }
        }

        public void PrintBookings(BookingsList bookings)
        {
            WriteLine("----- Bookings -----");

            if (bookings.Confirmed.Count <= 0)
            {
                WriteLine("No booked users.");
            }

            foreach (var booking in bookings.Confirmed.Select((value, index) => (Id: value.Id, Position: index + 1)))
            {
                WriteLine($"{booking.Position}\t{booking.Id}");
            }

            WriteLine("\n");
            WriteLine("----- Waiting List -----");

            if (bookings.WaitList.Count <= 0)
            {
                WriteLine("No users on waiting list.");
            }

            foreach (var booking in bookings.WaitList.Select((value, index) => (Id: value.Id, Position: index + 1)))
            {
                WriteLine($"{booking.Position}\t{booking.Id}");
            }
        }
    }
}