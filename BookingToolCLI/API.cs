using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingToolCLI
{


  public class API
  {
    private const int ConfirmedCapacity = 10;
    private readonly List<BookingEntry> confirmed = new List<BookingEntry>();
    private readonly List<BookingEntry> waitList = new List<BookingEntry>();

    public BookingResult MakeBooking(string id)
    {
      if (confirmed.Concat(waitList).Any(booking => StringComparer.Ordinal.Equals(booking.Id, id)))
        return new BookingResult(BookingStatus.duplicate);

      var entry = new BookingEntry(id);
      if (confirmed.Count < ConfirmedCapacity)
      {
        confirmed.Add(entry);
        return new BookingResult(BookingStatus.confirmed);
      }

      waitList.Add(entry);
      return new BookingResult(BookingStatus.waiting);
    }

    public bool RemoveBooking(string id)
    {
      var confirmedIndex = confirmed.FindIndex(booking => StringComparer.Ordinal.Equals(booking.Id, id));
      if (confirmedIndex >= 0)
      {
        confirmed.RemoveAt(confirmedIndex);
        if (waitList.Count > 0)
        {
          confirmed.Add(waitList[0]);
          waitList.RemoveAt(0);
        }
        return true;
      }

      var waitListIndex = waitList.FindIndex(booking => StringComparer.Ordinal.Equals(booking.Id, id));
      if (waitListIndex < 0)
        return false;

      waitList.RemoveAt(waitListIndex);
      return true;
    }

    public BookingsList GetBookings()
    {
      return new BookingsList(confirmed.ToArray(), waitList.ToArray());
    }

  }
}
