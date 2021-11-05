using Microsoft.EntityFrameworkCore;
using SampleTaskWeb.Server.Repositories;
using SampleTaskWeb.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleTaskWeb.DAL
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

    /// <inheritDoc/>
    public Task<Device> AddAsync(Device entity)
    {
      throw new NotImplementedException();
    }

    /// <inheritDoc/>
    public Task Delete(Device entity)
    {
      throw new NotImplementedException();
    }

    /// <inheritDoc/>
    public Task<IEnumerable<Device>> GetAllAsync()
    {
      throw new NotImplementedException();
    }
  }
}
