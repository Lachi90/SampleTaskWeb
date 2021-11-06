using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SampleTaskWeb.DAL.Repositories;
using SampleTaskWeb.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SampleTaskWeb.DAL.Tests
{
  public class DeviceRepositoryTests
  {
    private readonly DeviceRepository _deviceRepository;

    public DeviceRepositoryTests()
    {
      string dbName = Guid.NewGuid().ToString();
      DbContextOptions<DeviceDbContext> options = new DbContextOptionsBuilder<DeviceDbContext>()
                      .UseInMemoryDatabase(databaseName: dbName).Options;

      DeviceDbContext deviceDbContextContext = new(options);

      _deviceRepository = new DeviceRepository(deviceDbContextContext);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnDeviceWithGuid()
    {
      // Arrange
      var device = new Device()
      {
        DeviceName = "TestDevice"
      };
      
      // Act
      device = await _deviceRepository.AddAsync(device);

      // Assert
      device.Id.Should().NotBeEmpty();

    }

    [Fact]
    public async Task AddAsync_ShouldReturnNullWhenGivenNull()
    {
      // Act
      var device = await _deviceRepository.AddAsync(null);

      // Assert
      device.Should().BeNull();
    }

  }
}
