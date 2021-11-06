using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleTaskWeb.Server.Repositories;
using SampleTaskWeb.Shared;

namespace SampleTaskWeb.Server.Controllers
{
  /// <summary>
  /// API Controller for handling the devices
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class DeviceController : ControllerBase
  {
    private readonly IDeviceRepository _deviceRepository;

    public DeviceController(IDeviceRepository deviceRepository)
    {
      _deviceRepository = deviceRepository;
    }

    /// <summary>
    /// Gets a list of all devices
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllDevicesAsync()
    {
      var devices = await _deviceRepository.GetAllAsync();
      return Ok(devices);
    }

    /// <summary>
    /// Adds a device to the database
    /// </summary>
    /// <param name="device">The device to be added</param>
    [HttpPost]
    public async Task<IActionResult> AddDeviceAsync(Device device)
    {
      var deviceAdded = await _deviceRepository.AddAsync(device);
      return Ok(deviceAdded);
    }

    /// <summary>
    /// Deletes a device from the database
    /// </summary>
    /// <param name="device"></param>
    [HttpPost]
    public async Task<IActionResult> DeleteDeviceAsync(Device device)
    {
      await _deviceRepository.DeleteAsync(device);
      return Ok();
    }
  }
}
