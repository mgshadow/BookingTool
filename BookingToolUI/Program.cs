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
                if (input == null || input == ui.ExitCommand)
                {
                    return;
                }
                else if (input == ui.BookCommand)
                {
                    ui.WriteLine("Please input ID to book: ");
                    var result = api.MakeBooking(ui.ReadLine());
                    ui.WriteLine(ui.ConvertStatusToString(result.Status));
                }
                else if (input == ui.RemoveCommand)
                {
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
                }
                else if (input == ui.ListCommand)
                {
                    var bookings = api.GetBookings();
                    ui.PrintBookings(bookings);
                }
                else
                {
                    ui.WriteLine("Invalid input.");
                }
            }
        }
    }
}
