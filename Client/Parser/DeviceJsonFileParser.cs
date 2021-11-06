using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using SampleTaskWeb.Client.Exceptions;
using SampleTaskWeb.Shared;

namespace SampleTaskWeb.Client.Parser
{
  /// <summary>
  /// Parses a given Json file
  /// </summary>
  public static class DeviceJsonFileParser
  {
    /// <summary>
    /// Parses a device json file 
    /// </summary>
    /// <param name="deviceJsonFile">File to be parsed</param>
    /// <returns>Returns a list of devices</returns>
    public static async Task<IEnumerable<Device>> ParseDevicesFromJsonFileAsync(IBrowserFile deviceJsonFile)
    {
      if (deviceJsonFile.ContentType != "application/json")
      {
        throw new InvalidFileException("The uploaded file is not a json file!");
      }

      if (deviceJsonFile.Size == 0)
      {
        throw new InvalidFileSizeException("The uploaded file is empty!");
      }

      var memoryStream = new MemoryStream();
      await deviceJsonFile.OpenReadStream().CopyToAsync(memoryStream);
      memoryStream.Seek(0, SeekOrigin.Begin);

      IEnumerable<Device> devices = new List<Device>();
      using (var streamReader = new StreamReader(memoryStream))
      {
        var jsonContent = await streamReader.ReadToEndAsync();
        devices = JsonConvert.DeserializeObject<DevicesCollection>(jsonContent).Devices;
      }

      return devices;
    }
  }
}
