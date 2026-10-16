using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingToolCLI;
using System;
using System.Linq;


namespace UnitTests
{


  [TestClass]
  public class UnitTests
  {
    private string[] c9 = new[] { "u01", "u02", "u03", "u04","u05","u06","u07","u08","u09" };
    private string[] w2 = new[] { "w01", "w02" };
    private string[] c10 = new[] { "u01", "u02", "u03", "u04","u05","u06","u07","u08","u09", "u10" };

    [TestMethod]
    public void FirstBookingTest()
    {
      var api = new API();

      Assert.AreEqual(BookingStatus.confirmed, api.MakeBooking("alex").Status);
      var result = api.GetBookings();
      Assert.AreEqual(1, result.Confirmed.Count);
      Assert.AreEqual("alex", result.Confirmed[0]);
      Assert.AreEqual(0, result.WaitList.Count);

    }

    [TestMethod]
    public void LastAvailablePlaceTest()
    {
      var api = new API();

      CreateBookings(api, c9);


      Assert.AreEqual(BookingStatus.confirmed, api.MakeBooking($"u10").Status);

      var result = api.GetBookings();
      Assert.AreEqual(10, result.Confirmed.Count);
      Assert.AreEqual("u10", result.Confirmed[9]);
      Assert.AreEqual(0, result.WaitList.Count);

    }

    [TestMethod]
    public void FullWorkshopTest()
    {
      var api = new API();

      CreateBookings(api, c10);

      

      Assert.AreEqual(BookingStatus.waiting, api.MakeBooking($"w01").Status);

      var result = api.GetBookings();
      Assert.AreEqual(10, result.Confirmed.Count);
      Assert.AreEqual(1, result.WaitList.Count);
      Assert.AreEqual("w01", result.WaitList[0]);

    }

    [TestMethod]
    public void DuplicateWithSpaceTest()
    {
      var api = new API();

      CreateBookings(api, "alex","bea","uhris");
      
      var resultBefore = api.GetBookings();      

      Assert.AreEqual(BookingStatus.duplicate, api.MakeBooking($"alex").Status);

      var resultAfter = api.GetBookings();

      Assert.AreEqual(resultBefore, resultAfter);
    }

    [TestMethod]
    public void DuplicateWhenFullTest()
    {
      var api = new API();

      CreateBookings(api, c10);      

      var resultBefore = api.GetBookings();

      Assert.AreEqual(BookingStatus.duplicate, api.MakeBooking($"u04").Status);
      
      var resultAfter = api.GetBookings();

      Assert.AreEqual(resultBefore, resultAfter);
    }

    [TestMethod]
    public void DuplicateWaitingEntryTest()
    {
      var api = new API();

      CreateBookings(api, c10);
      CreateBookings(api, w2);     

      var resultBefore = api.GetBookings();

      Assert.AreEqual(BookingStatus.duplicate, api.MakeBooking($"w01").Status);

      var resultAfter = api.GetBookings();

      Assert.AreEqual(resultBefore, resultAfter);
    }

    [TestMethod]
    public void PreserveWaitingOrderTest()
    {
      var api = new API();

      CreateBookings(api, c10);
      CreateBookings(api, w2);


      var resultBefore = api.GetBookings();

      Assert.AreEqual(BookingStatus.waiting, api.MakeBooking($"w03").Status);

      var resultAfter = api.GetBookings();

      Assert.AreNotEqual(resultBefore, resultAfter);
      Assert.AreEqual(resultBefore.Confirmed, resultAfter.Confirmed);
      Assert.AreEqual(resultBefore.WaitList.ToArray(), resultAfter.WaitList.Take(2).ToArray());
      Assert.AreEqual("w3", resultAfter.WaitList.Last());
    }

    [TestMethod]
    public void CaseSensitiveIdsTest()
    {
      var api = new API();

      Assert.AreEqual(BookingStatus.confirmed, api.MakeBooking("alex").Status);
      Assert.AreEqual(BookingStatus.confirmed, api.MakeBooking("Alex").Status);

      var result = api.GetBookings();
      Assert.AreEqual(2, result.Confirmed.Count);
      Assert.AreEqual("alex", result.Confirmed[0]);
      Assert.AreEqual("Alex", result.Confirmed[0]);
      Assert.AreEqual(0, result.WaitList.Count);

    }


    [TestMethod]
    public void OneSequeceTest()
    {
      var api = new API();

      CreateBookings(api, c9);
      var result = api.GetBookings();
      Assert.AreEqual(c9, result.Confirmed.Select(c => c.Id).ToArray());
      Assert.AreEqual(0, result.WaitList.Count);

      Assert.AreEqual(BookingStatus.confirmed, api.MakeBooking("u10").Status);
      var result01 = api.GetBookings();
      Assert.AreEqual(c10, result01.Confirmed.Select(c => c.Id).ToArray());

      Assert.AreEqual(BookingStatus.waiting, api.MakeBooking("w01").Status);
      var result02 = api.GetBookings();
      Assert.AreEqual(c10, result02.Confirmed.Select(c => c.Id).ToArray());
      Assert.AreEqual(new[] {"w01"} , result02.WaitList.Select(c => c.Id).ToArray());

      Assert.AreEqual(BookingStatus.waiting, api.MakeBooking("w02").Status);
      var result03 = api.GetBookings();
      Assert.AreEqual(c10, result03.Confirmed.Select(c => c.Id).ToArray());
      Assert.AreEqual(w2, result03.WaitList.Select(c => c.Id).ToArray());

      Assert.AreEqual(BookingStatus.duplicate, api.MakeBooking("w01").Status);
      var result04 = api.GetBookings();
      Assert.AreEqual(result03, result04);

      Assert.AreEqual(BookingStatus.duplicate, api.MakeBooking("u03").Status);
      var result05 = api.GetBookings();
      Assert.AreEqual(result03, result05);




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
