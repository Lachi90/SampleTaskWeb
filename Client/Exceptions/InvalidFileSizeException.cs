using System;

namespace SampleTaskWeb.Client.Exceptions
{
  /// <summary>
  /// Exception get's thrown for empty files
  /// </summary>
  public class InvalidFileSizeException : Exception
  {
    public InvalidFileSizeException(string message) : base(message)
    {
      
    }
  }
}
