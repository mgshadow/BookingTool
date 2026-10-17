using BookingToolCLI;

namespace BookingToolUI
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var ui = new ConsoleInterface();
      var api = new API();

      while (true)
      {
        ui.WriteLine("\n");
        ui.WriteLine(ui.ShowMenu());

        var input = ui.ReadLine();

        switch (input)
        {
          // Book
          case "1":
            ui.WriteLine("Please input ID to book: ");
            var result = api.MakeBooking(ui.ReadLine());
            ui.WriteLine(ui.ConvertStatusToString(result.Status));
            break;

          // Remove
          case "2":
            ui.WriteLine("Please input ID to remove: ");
            var remove = api.RemoveBooking(ui.ReadLine());

            if (remove)
            {
              ui.WriteLine("User has been removed.");
            }
            else
            {
              ui.WriteLine("User does not exist.");
            }

            break;

          // List
          case "3":
            var bookings = api.GetBookings();
            ui.PrintBookings(bookings);
            break;

          case null:
          case "0":
            return;

          default:
            ui.WriteLine("Invalid input.");
            break;
        }
      }
    }
  }
}
