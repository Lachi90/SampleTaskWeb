using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SampleTaskWeb.Shared;
using System.Net.Http.Json;
using System;

namespace SampleTaskWeb.Client.Manager
{
  /// <summary>
  /// Handles all http requests to the backend regarding devices
  /// </summary>
  public class DeviceManager
  {
    private readonly HttpClient _httpClient;

    public DeviceManager(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    /// <summary>
    /// Sends the devices read from json to the backend for storing it
    /// </summary>
    /// <param name="devices">The devices to be sent</param>
    public async Task SendDevicesAsync(IEnumerable<Device> devices)
    {
      foreach (var device in devices)
      {
        await _httpClient.PostAsJsonAsync("/device/create", device);
      }
    }

    /// <summary>
    /// Gets all the devices from the backend
    /// </summary>
    /// <returns>A list of devices</returns>
    public async Task<IEnumerable<Device>> GetAllDevicesAsync()
    {
      var devices = await _httpClient.GetFromJsonAsync<IEnumerable<Device>>("/device/devices");
      return devices;
    }

    /// <summary>
    /// Deletes a device from the backend
    /// </summary>
    /// <param name="device">The device to deleted</param>
    public async Task DeleteDeviceAsync(Device device)
    {
      await _httpClient.PostAsJsonAsync("/device/delete", device);
    }
  }
}
