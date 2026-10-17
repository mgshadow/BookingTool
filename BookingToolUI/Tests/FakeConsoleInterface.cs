using System;
using System.Collections.Generic;

namespace BookingToolUI.Tests
{
  public class FakeConsoleInterface : IUserInterface
  {
    public string Input { get; }
    public List<string> Outputs { get; }

    public FakeConsoleInterface(string input = "")
    {
      Input = input;
      Outputs = new List<string>();
    }

    public string ReadLine()
    {
      return Input;
    }

    public void WriteLine(string text)
    {
      Outputs.Add(text);
    }
  }
}
