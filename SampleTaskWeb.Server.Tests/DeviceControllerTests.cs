using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SampleTaskWeb.Server.Controllers;
using SampleTaskWeb.Server.Repositories;
using SampleTaskWeb.Shared;
using Xunit;

namespace SampleTaskWeb.Server.Tests
{
  public class DeviceControllerTests
  {
    private readonly DeviceController _deviceController;
    private readonly Mock<IDeviceRepository> _deviceRepository;

    public DeviceControllerTests()
    {
      _deviceRepository = new Mock<IDeviceRepository>();
      _deviceController = new DeviceController(_deviceRepository.Object);
    }

    [Fact]
    public async Task GetAllDevicesAsync_ShouldReturnAllDevices()
    {
      // Arrange
      var device = new Device() { InternalId = Guid.NewGuid(), Name = "TestDevice" };

      _deviceRepository.Setup(x => x.GetAllAsync())
        .ReturnsAsync(new List<Device>() { device });

      // Act
      var actionResult = await _deviceController.GetAllDevicesAsync();

      // Assert
      var okResult = actionResult.Should().BeOfType<OkObjectResult>().Subject;
      var devices = okResult.Value.Should().BeAssignableTo<IEnumerable<Device>>().Subject;
      devices.Should().HaveCount(1);
    }

    [Fact]
    public async Task AddDeviceAsync_ShouldAddDeviceSuccessfully()
    {
      // Arrange
      var device = new Device() { InternalId = Guid.NewGuid(), Name = "TestDevice"};

      _deviceRepository.Setup(x => x.AddAsync(It.IsAny<Device>()))
        .ReturnsAsync(device);

      // Act
      var actionResult = await _deviceController.AddDeviceAsync(device);

      // Assert
      var okResult = actionResult.Should().BeOfType<OkObjectResult>().Subject;
      var deviceAdded = okResult.Value.Should().BeAssignableTo<Device>().Subject;
      deviceAdded.Name.Should().BeEquivalentTo("TestDevice");
    }

    [Fact]
    public async Task DeleteDeviceAsync_ShouldRemoveDeviceSuccessfully()
    {
      // Arrange
      _deviceRepository.Setup(x => x.DeleteAsync(It.IsAny<Device>()))
        .Returns(Task.CompletedTask);

      // Act
      var actionResult = await _deviceController.DeleteDeviceAsync(It.IsAny<Device>());

      // Assert
      actionResult.Should().BeOfType<OkResult>();
    }
  }
}
