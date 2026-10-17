using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingToolCLI
{
  public class BookingsList : IEquatable<BookingsList>
  {
    public BookingsList(IReadOnlyList<BookingEntry> confirmed, IReadOnlyList<BookingEntry> waitList)
    {
      Confirmed = confirmed;
      WaitList = waitList;
    }

    public IReadOnlyList<BookingEntry> Confirmed { get; }
    public IReadOnlyList<BookingEntry> WaitList { get; }

    public bool Equals(BookingsList other)
    {
      return !ReferenceEquals(other, null) && ListsEqual(Confirmed, other.Confirmed) && ListsEqual(WaitList, other.WaitList);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as BookingsList);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (GetListHashCode(Confirmed) * 397) ^ GetListHashCode(WaitList);
      }
    }

    public static bool operator ==(BookingsList left, BookingsList right)
    {
      return ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));
    }

    public static bool operator !=(BookingsList left, BookingsList right)
    {
      return !(left == right);
    }

    private static bool ListsEqual(IReadOnlyList<BookingEntry> left, IReadOnlyList<BookingEntry> right)
    {
      return ReferenceEquals(left, right) || (left != null && right != null && left.SequenceEqual(right));
    }

    private static int GetListHashCode(IReadOnlyList<BookingEntry> entries)
    {
      if (entries == null)
        return 0;

      unchecked
      {
        int hash = 17;
        foreach (var entry in entries)
          hash = hash * 31 + (entry == null ? 0 : entry.GetHashCode());
        return hash;
      }
    }
  }
}
