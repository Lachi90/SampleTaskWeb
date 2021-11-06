using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleTaskWeb.Shared;

namespace SampleTaskWeb.Server.Repositories
{
  /// <summary>
  /// Repository for managing devices
  /// </summary>
  public class DeviceRepository : IDeviceRepository
  {
    private readonly DeviceDbContext _deviceDbContext;

    public DeviceRepository(DeviceDbContext deviceDbContext)
    {
      _deviceDbContext = deviceDbContext;
    }

    /// <summary>
    /// Adds a new device to the database
    /// </summary>
    /// <param name="device">Device to be saved</param>
    /// <returns>The device with internal assigned id</returns>
    public async Task<Device> AddAsync(Device device)
    {
      if (device != null)
      {
        device.Id = Guid.NewGuid();
        await _deviceDbContext.Set<Device>().AddAsync(device);
        await _deviceDbContext.SaveChangesAsync();
      }

      return device;
    }

    /// <summary>
    /// Deletes a give device from the database
    /// </summary>
    /// <param name="device"></param>
    public async Task DeleteAsync(Device device)
    {
      _deviceDbContext.Set<Device>().Remove(device);
      await _deviceDbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Gets all devices from the database
    /// </summary>
    /// <returns>A list of all devices</returns>
    public async Task<IEnumerable<Device>> GetAllAsync()
    {
      return await _deviceDbContext.Set<Device>().ToListAsync();
    }
  }
}
