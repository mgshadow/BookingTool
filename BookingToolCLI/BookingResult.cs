using System;

namespace BookingToolCLI
{
  public class BookingResult : IEquatable<BookingResult>
  {
    public BookingResult()
    {
    }

    public BookingResult(BookingStatus status)
    {
      Status = status;
    }

    public BookingStatus Status { get; }

    public bool Equals(BookingResult other)
    {
      return !ReferenceEquals(other, null) && Status == other.Status;
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as BookingResult);
    }

    public override int GetHashCode()
    {
      return Status.GetHashCode();
    }

    public static bool operator ==(BookingResult left, BookingResult right)
    {
      return ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));
    }

    public static bool operator !=(BookingResult left, BookingResult right)
    {
      return !(left == right);
    }
  }
}
