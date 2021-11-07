using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using SampleTaskWeb.Client.Parser;
using SampleTaskWeb.Shared;

namespace SampleTaskWeb.Client.Pages
{
  partial class Index
  {
    private IEnumerable<Device> _devices = new List<Device>();

    protected override async Task OnInitializedAsync()
    {
      await FetchData();
    }

    private async Task FileSelected(InputFileChangeEventArgs e)
    {
      try
      {
        var devices = await DeviceJsonFileParser.ParseDevicesFromJsonFileAsync(e.File);

        if (devices != null)
        {
          await _deviceManager.SendDevicesAsync(devices);
          await FetchData();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private async void DeleteButtonPressed(MouseEventArgs obj, Device device)
    {
      if (device != null)
      {
        await _deviceManager.DeleteDeviceAsync(device);
        await FetchData();
      }
    }

    private void OnDeviceClick(Device device)
    {
      _navigationManager.NavigateTo($"/device/{device.ToJsonString()}");
    }

    private async Task FetchData()
    {
      _devices = await _deviceManager.GetAllDevicesAsync();
    }
  }
}
