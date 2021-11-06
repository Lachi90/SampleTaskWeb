﻿using Microsoft.EntityFrameworkCore;
using SampleTaskWeb.Shared;

namespace SampleTaskWeb.DAL
{

  /// <summary>
  /// DbContext for the sqLite database
  /// </summary>
  public class DeviceDbContext : DbContext
  {
    public DeviceDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public virtual DbSet<Device> Devices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Device>(device =>
      {
        device.HasKey(e => e.Id);
        device.ToTable("Devices");
      });
    }
  }
}