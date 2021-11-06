using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SampleTaskWeb.Shared;
using System;
using System.Threading.Tasks;
using SampleTaskWeb.Server;
using SampleTaskWeb.Server.Repositories;
using Xunit;

namespace SampleTaskWeb.DAL.Tests
{
  public class DeviceRepositoryTests
  {
    private readonly DeviceRepository _deviceRepository;
    private readonly DeviceDbContext _deviceDbContextContext;

    public DeviceRepositoryTests()
    {
      string dbName = Guid.NewGuid().ToString();
      DbContextOptions<DeviceDbContext> options = new DbContextOptionsBuilder<DeviceDbContext>()
                      .UseInMemoryDatabase(databaseName: dbName).Options;

      _deviceDbContextContext = new(options);

      _deviceRepository = new DeviceRepository(_deviceDbContextContext);
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
      var devices = await _deviceRepository.GetAllAsync();
      devices.Should().HaveCount(1);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNullWhenGivenNull()
    {
      // Act
      var device = await _deviceRepository.AddAsync(null);

      // Assert
      device.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveEntry()
    {
      // Arrange
      var device = await _deviceRepository.AddAsync(new Device() { DeviceName = "TestDevice" });

      // Act 
      await _deviceRepository.DeleteAsync(device);

      // Assert
      var areDevicesExisting = await _deviceDbContextContext.Devices.AnyAsync(d => d.Id == device.Id);
      areDevicesExisting.Should().BeFalse();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllDevices()
    {
      // Arrange
      _ = await _deviceRepository.AddAsync(new Device() { DeviceName = "TestDevice" });

      // Act
      var devices = await _deviceRepository.GetAllAsync();

      // Arrange
      devices.Should().HaveCount(1);
    }
  }
}
