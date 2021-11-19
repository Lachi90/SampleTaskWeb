using System.Collections.Generic;

namespace SampleTaskWeb.Shared
{
  /// <summary>
  /// Contains the property name and values of the devices for comparison
  /// </summary>
  public class PropertyWithDeviceValues
  {
    /// <summary>
    /// Name of the property
    /// </summary>
    public string PropertyName { get; set; }

    /// <summary>
    /// Contains the property values of the devcies which should be compared
    /// </summary>
    public ICollection<string> PropertyValues { get; set; }
  }
}
