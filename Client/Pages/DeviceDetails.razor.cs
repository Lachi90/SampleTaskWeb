using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using SampleTaskWeb.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskWeb.Client.Pages
{
  partial class DeviceDetails
  {
    [Parameter]
    public string Device { get; set; }

    private List<DeviceProperty> _properties = new List<DeviceProperty>();

    protected override async Task OnInitializedAsync()
    {
      try
      {
        var deviceDeserialized = JsonConvert.DeserializeObject<Device>(Device);

        var _deviceProperties = GetFieldsWithValues(deviceDeserialized);

        foreach (var property in _deviceProperties)
        {
          _properties.Add(new DeviceProperty()
          {
            PropertyKey = property.Key,
            PropertyValue = property.Value
          });
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

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
