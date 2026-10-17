using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingToolCLI;

namespace UnitTests
{
  [TestClass]
  public class CoreTests
  {
    [TestMethod]
    public void BookingEntryEqualityTest()
    {
      var first = new BookingEntry("alex");
      var same = new BookingEntry("alex");
      var different = new BookingEntry("Alex");

      Assert.IsTrue(first.Equals(same));
      Assert.IsTrue(first.Equals((object)same));
      Assert.IsTrue(first == same);
      Assert.IsFalse(first != same);
      Assert.AreEqual(first.GetHashCode(), same.GetHashCode());
      Assert.IsFalse(first.Equals(different));
      Assert.IsTrue(first != different);
      Assert.IsFalse(first.Equals((BookingEntry)null));
      Assert.IsFalse(first == null);
      Assert.IsTrue(null == (BookingEntry)null);
    }

    [TestMethod]
    public void BookingsListEqualityTest()
    {
      var first = new BookingsList(new[] { new BookingEntry("alex"), new BookingEntry("bea") }, new[] { new BookingEntry("chris") });
      var same = new BookingsList(new[] { new BookingEntry("alex"), new BookingEntry("bea") }, new[] { new BookingEntry("chris") });
      var reordered = new BookingsList(new[] { new BookingEntry("bea"), new BookingEntry("alex") }, new[] { new BookingEntry("chris") });
      var differentWaitList = new BookingsList(new[] { new BookingEntry("alex"), new BookingEntry("bea") }, new BookingEntry[0]);

      Assert.IsTrue(first.Equals(same));
      Assert.IsTrue(first.Equals((object)same));
      Assert.IsTrue(first == same);
      Assert.IsFalse(first != same);
      Assert.AreEqual(first.GetHashCode(), same.GetHashCode());
      Assert.IsFalse(first.Equals(reordered));
      Assert.IsFalse(first.Equals(differentWaitList));
      Assert.IsTrue(first != reordered);
      Assert.IsFalse(first.Equals((BookingsList)null));
      Assert.IsFalse(first == null);
      Assert.IsTrue(null == (BookingsList)null);

      var nullLists = new BookingsList(null, null);
      Assert.IsTrue(nullLists.Equals(new BookingsList(null, null)));
      Assert.IsFalse(nullLists.Equals(first));
    }

    [TestMethod]
    public void BookingResultEqualityTest()
    {
      var first = new BookingResult(BookingStatus.confirmed);
      var same = new BookingResult(BookingStatus.confirmed);
      var different = new BookingResult(BookingStatus.waiting);

      Assert.IsTrue(first.Equals(same));
      Assert.IsTrue(first.Equals((object)same));
      Assert.IsTrue(first == same);
      Assert.IsFalse(first != same);
      Assert.AreEqual(first.GetHashCode(), same.GetHashCode());
      Assert.IsFalse(first.Equals(different));
      Assert.IsTrue(first != different);
      Assert.IsFalse(first.Equals((BookingResult)null));
      Assert.IsFalse(first == null);
      Assert.IsTrue(null == (BookingResult)null);
      Assert.IsTrue(first.Equals(new BookingResult()));
    }
  }
}
