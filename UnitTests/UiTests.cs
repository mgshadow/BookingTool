using BookingToolUI.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingToolCLI;

namespace UnitTests
{

  private string[] c9 = new[] { "u01", "u02", "u03", "u04", "u05", "u06", "u07", "u08", "u09" };
  private string[] w2 = new[] { "w01", "w02" };
  private string[] c10 = new[] { "u01", "u02", "u03", "u04", "u05", "u06", "u07", "u08", "u09", "u10" };

  [TestClass]
  public class UiTests
  {
    [TestMethod]
    public void ShowCorrectMenuTest()
    {
      var ui = new FakeConsoleInterface();
      ui.WriteLine("Das ist mein Menu");

      Assert.AreEqual(ui.Outputs[0], "Das ist mein Menu");
    }

    [TestMethod]
    public void InputTest()
    {
      var ui = new FakeConsoleInterface("1");
      Assert.AreEqual(ui.ReadLine(), "1");
    }

    [TestMethod]
    public void ShowBookingsTest()
    {
      var ui = new FakeConsoleInterface();
      var api = new API();

      var booking1 = api.MakeBooking("alex");
      Assert.AreEqual(ui.convertStatusToString(booking1.status), "Booking confirmed!");

      CreateBookings(api, c9);

      var booking2 = api.MakeBooking("erich"); 
      Assert.AreEqual(ui.convertStatusToString(booking2.status), "You are on the waiting list!");

      var booking3 = api.MakeBooking("alex");
      Assert.AreEqual(ui.convertStatusToString(booking3.status), "User already exists!");
    }

    [TestMethod]
    public void AddBookingTest()
    {

    }
  }
}
