using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using SampleTaskWeb.Client.Parser;

namespace SampleTaskWeb.Client.Shared
{
  partial class MainLayout
  {
    private async Task FileSelected(InputFileChangeEventArgs e)
    {
      try
      {
        var devices = await DeviceJsonFileParser.ParseDevicesFromJsonFileAsync(e.File);

        if (devices != null)
        {
          await _deviceManager.SendDevicesAsync(devices);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
