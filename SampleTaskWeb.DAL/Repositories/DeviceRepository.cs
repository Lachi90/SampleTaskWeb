using Microsoft.EntityFrameworkCore;
using SampleTaskWeb.Server.Repositories;
using SampleTaskWeb.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleTaskWeb.DAL.Repositories
{
  /// <summary>
  /// Repository for managing devices
  /// </summary>
  public class DeviceRepository : IGenericRepository<Device>
  {
    private readonly DbContext _dbContext;

    public DeviceRepository(DbContext dbContext)
    {
      _dbContext = dbContext;
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
        await _dbContext.Set<Device>().AddAsync(device);
        await _dbContext.SaveChangesAsync();
      }

      return device;
    }

    /// <summary>
    /// Deletes a give device from the database
    /// </summary>
    /// <param name="device"></param>
    public async Task DeleteAsync(Device device)
    {
      _dbContext.Set<Device>().Remove(device);
      await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Gets all devices from the database
    /// </summary>
    /// <returns>A list of all devices</returns>
    public async Task<IEnumerable<Device>> GetAllAsync()
    {
      return await _dbContext.Set<Device>().ToListAsync();
    }
  }
}
