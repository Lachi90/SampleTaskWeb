using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using SampleTaskWeb.Client.Parser;
using SampleTaskWeb.Shared;

namespace SampleTaskWeb.Client.Shared
{
  partial class MainLayout
  {
    private IEnumerable<Device> _devices = new List<Device>();

    protected override async Task OnInitializedAsync()
    {
      _devices = await _deviceManager.GetAllDevicesAsync();
    }

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
