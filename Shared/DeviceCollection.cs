using System.Collections.Generic;

namespace SampleTaskWeb.Shared
{
  /// <summary>
  /// Contains all the devices
  /// </summary>
  public class DeviceCollection
  {
    public ICollection<Device> Devices { get; set; }
  }
}
