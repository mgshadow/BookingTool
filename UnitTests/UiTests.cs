using BookingToolUI.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
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

    }

    [TestMethod]
    public void AddBookingTest()
    {

    }
  }
}
