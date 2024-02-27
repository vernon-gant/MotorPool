﻿using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Manager;

public static class ManagerLINQExtension
{

    public static List<VehicleViewModel> ForManager(this List<VehicleViewModel> vehicles, int managerId) => vehicles.Where(vehicle => vehicle.ManagerIds.Contains(managerId)).ToList();

    public static List<DriverViewModel> ForManager(this List<DriverViewModel> drivers, int managerId) => drivers.Where(driver => driver.ManagerIds.Contains(managerId)).ToList();

    public static List<EnterpriseViewModel> ForManager(this List<EnterpriseViewModel> enterprises, int managerId) => enterprises.Where(enterprise => enterprise.ManagerIds.Contains(managerId)).ToList();

}