using System;

namespace BookingToolCLI
{
  public class BookingEntry : IEquatable<BookingEntry>
  {
    public BookingEntry(string id)
    {
      Id = id;
    }

    public string Id { get; }

    public bool Equals(BookingEntry other)
    {
      return !ReferenceEquals(other, null) && StringComparer.Ordinal.Equals(Id, other.Id);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as BookingEntry);
    }

    public override int GetHashCode()
    {
      return Id == null ? 0 : StringComparer.Ordinal.GetHashCode(Id);
    }

    public static bool operator ==(BookingEntry left, BookingEntry right)
    {
      return ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));
    }

    public static bool operator !=(BookingEntry left, BookingEntry right)
    {
      return !(left == right);
    }
  }
}
