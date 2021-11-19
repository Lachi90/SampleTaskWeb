using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
    private ICollection<PropertyWithDeviceValues> _propertyWithDeviceValues = new List<PropertyWithDeviceValues>();

    protected override async Task OnInitializedAsync()
    {
      var deviceIds = DeviceIds.Split(";").ToList();
      var allDevices = await _deviceManager.GetAllDevicesAsync();
      _devices = allDevices.Where(x => deviceIds.Contains(x.InternalId.ToString())).ToList();

      var properties = GetFieldsWithValues(_devices.FirstOrDefault()).Select(x => x.Key);
      foreach (var property in properties)
      {
        var propertyValues = new List<string>();
        foreach (var device in _devices)
        {
          var propsOfDevice = GetFieldsWithValues(device);
          var value = propsOfDevice.SingleOrDefault(x => x.Key == property).Value;
          if (!string.IsNullOrEmpty(value))
          {
            propertyValues.Add(value);
          }
        }

        var propertyWithDeviceValues = new PropertyWithDeviceValues()
        {
          PropertyName = property,
          PropertyValues = propertyValues
        };

        _propertyWithDeviceValues.Add(propertyWithDeviceValues);
      }
    }

    private bool CheckForValueEquality(string propertyName, string propertyValue)
    {
      var propertyValues = _propertyWithDeviceValues.SingleOrDefault(x => x.PropertyName == propertyName).PropertyValues;

      return propertyValues.Where(x => x == propertyValue).Count() > 1;
    }

    private void BackButtonClicked(MouseEventArgs obj)
    {
      _navigationManager.NavigateTo("/");
    }

    private Dictionary<string, string> GetFieldsWithValues(object obj)
    {
      var keyValuePairs = new Dictionary<string, string>();

      var tmp = obj.GetType().GetProperties();
      foreach (var key in tmp)
      {
        keyValuePairs.Add(key.Name, key.GetValue(obj)?.ToString());
      }

      return keyValuePairs;
    }
  }
}
