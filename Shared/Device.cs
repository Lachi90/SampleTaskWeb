using System;
using Newtonsoft.Json;

namespace SampleTaskWeb.Shared
{
  /// <summary>
  /// Represents a device
  /// </summary>
  public class Device
  {
    /// <summary>
    /// Internal Identifier
    /// </summary>
    public Guid InternalId { get; set; }

    /// <summary>
    /// Name of the device
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Indicates whether the device is failsafe
    /// </summary>
    public bool FailSafe { get; set; }

    /// <summary>
    /// The device's type id
    /// </summary>
    public string DeviceTypeId { get; set; }

    /// <summary>
    /// Minimal operating temperature
    /// </summary>
    public int TempMin { get; set; }

    /// <summary>
    /// Maximal operating temperature
    /// </summary>
    public int TempMax { get; set; }

    /// <summary>
    /// Indicates the installation position of the device (horizontal or vertical)
    /// </summary>
    public string InstallationPosition { get; set; }

    /// <summary>
    /// Indicates if the device fits in a 19 inch cabinet
    /// </summary>
    public bool InsertInto19InchCabinet { get; set; }

    /// <summary>
    /// Indicates if the device is a terminal element
    /// </summary>
    public bool? TerminalElement { get; set; }

    /// <summary>
    /// Indicates if the device can work in advanced environmental conditions
    /// </summary>
    public bool? AdvancedEnvironmentConditions { get; set; }

    /// <summary>
    /// Converts the instance of the class to a json string
    /// </summary>
    /// <returns>A json representation of the instance</returns>
    public string ToJsonString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}
