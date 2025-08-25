using MachineMonitoring.Data;
using MachineMonitoring.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineMonitoring.Services;

public class MachineService : IMachineService
{
    private readonly ApplicationDbContext _context;

    public MachineService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Machine> CreateMachineAsync(Machine machine)
    {
        machine.Id = Guid.NewGuid();
        _context.Machines.Add(machine);
        await _context.SaveChangesAsync();
        return machine;
    }

    public async Task<IEnumerable<Machine>> GetAllMachinesAsync(MachineStatus? status)
    {
        if (status.HasValue)
        {
            return await _context.Machines.Where(m => m.Status == status.Value).ToListAsync();
        }
        return await _context.Machines.ToListAsync();
    }

    public async Task<Machine?> GetMachineByIdAsync(Guid id)
    {
        return await _context.Machines.FindAsync(id);
    }

    public async Task<Machine?> UpdateTelemetryAsync(Guid id, string location, MachineStatus status)
    {
        var machine = await GetMachineByIdAsync(id);
        if (machine == null)
        {
            return null;
        }

        machine.Location = location;
        machine.Status = status;

        _context.Machines.Update(machine);
        await _context.SaveChangesAsync();
        return machine;
    }
}