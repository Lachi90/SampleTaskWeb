using System;

namespace SampleTaskWeb.Client.Exceptions
{
  /// <summary>
  /// Exception get's thrown when file doesn't have the correct mime type
  /// </summary>
  public class InvalidFileException : Exception
  {
    public InvalidFileException(string message) : base(message)
    {
      
    }
  }
}
