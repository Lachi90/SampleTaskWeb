using Microsoft.AspNetCore.Components;
using SampleTaskWeb.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskWeb.Client.Pages
{
  public partial class DeviceComparison
  {
    [Parameter]
    public string DeviceIds { get; set; }

    private ICollection<Device> _devices = new List<Device>();

    protected override async Task OnInitializedAsync()
    {
      var deviceIds = DeviceIds.Split(";").ToList();
      var allDevices = await _deviceManager.GetAllDevicesAsync();
      _devices = allDevices.Where(x => deviceIds.Contains(x.InternalId.ToString())).ToList();
    }


  }
}
