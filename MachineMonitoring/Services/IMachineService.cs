using MachineMonitoring.Models;

namespace MachineMonitoring.Services;

public interface IMachineService
{
    Task<IEnumerable<Machine>> GetAllMachinesAsync(MachineStatus? status);
    Task<Machine?> GetMachineByIdAsync(Guid id);
    Task<Machine> CreateMachineAsync(Machine machine);
    Task<Machine?> UpdateTelemetryAsync(Guid id, string location, MachineStatus status);
}