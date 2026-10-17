using BookingToolUI.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingToolCLI;

namespace UnitTests
{
  [TestClass]
  public class UiTests
  {
    private string[] c9 = new[] { "u01", "u02", "u03", "u04", "u05", "u06", "u07", "u08", "u09" };

    [TestMethod]
    public void ShowMenuTest()
    {
      var ui = new FakeConsoleInterface();
      Assert.AreEqual(ui.ShowMenu(), "1 = Book | 2 = Remove | 3 = List | 0 = Exit\n-------------------------------------------");
    }

    [TestMethod]
    public void OutputTest()
    {
      var ui = new FakeConsoleInterface();
      ui.WriteLine("This is some random output.");

      Assert.AreEqual(ui.Outputs[0], "This is some random output.");
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
      Assert.AreEqual(ui.ConvertStatusToString(booking1.Status), "Booking confirmed!");

      CreateBookings(api, c9);

      var booking2 = api.MakeBooking("erich");
      Assert.AreEqual(ui.ConvertStatusToString(booking2.Status), "You are on the waiting list!");

      var booking3 = api.MakeBooking("alex");
      Assert.AreEqual(ui.ConvertStatusToString(booking3.Status), "User already exists!");
    }

    private void CreateBookings(API api, params string[] ids)
    {
      foreach (var id in ids)
      {
        api.MakeBooking(id);
      }
    }
  }
}
