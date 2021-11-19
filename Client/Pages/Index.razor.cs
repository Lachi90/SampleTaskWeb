using System;
using System.Collections.Generic;
using System.Linq;
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
    private ICollection<Device> _selectedDevices = new List<Device>();

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
        StateHasChanged();
      }
    }

    private Action DeviceChecked(bool isSelected, Device device)
    {
      if (device != null)
      {
        if (isSelected)
        {
          _selectedDevices.Add(device);
        }
        else
        {
          if (_selectedDevices.Contains(device))
          {
            _selectedDevices.Remove(device);
          }
        }
      }

      return null;
    }

    private void OnComparisonButtonClicked()
    {
      var deviceIds = _selectedDevices.Select(x => x.InternalId.ToString()).ToArray();
      var deviceIdsconcatenated = string.Join(";", deviceIds);

      _navigationManager.NavigateTo($"/comparison/{deviceIdsconcatenated}");
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
