using MachineMonitoring.Models;

namespace MachineMonitoring.DTOs;

public class UpdateTelemetryDto
{
    public string Location { get; set; }
    public MachineStatus Status { get; set; }
}