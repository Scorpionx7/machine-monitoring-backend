using MachineMonitoring.DTOs;
using MachineMonitoring.Models;
using MachineMonitoring.Services;
using Microsoft.AspNetCore.Mvc;

namespace MachineMonitoring.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MachinesController : ControllerBase
{
    private readonly IMachineService _machineService;

    public MachinesController(IMachineService machineService)
    {
        _machineService = machineService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMachines([FromQuery] MachineStatus? status)
    {
        var machines = await _machineService.GetAllMachinesAsync(status);
        return Ok(machines);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMachineById(Guid id)
    {
        var machine = await _machineService.GetMachineByIdAsync(id);
        return machine == null ? NotFound() : Ok(machine);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMachine([FromBody] CreateMachineDto createDto)
    {
        var machine = new Machine
        {
            Name = createDto.Name,
            Location = createDto.Location,
            Status = MachineStatus.Desligada 
        };

        var newMachine = await _machineService.CreateMachineAsync(machine);
        return CreatedAtAction(nameof(GetMachineById), new { id = newMachine.Id }, newMachine);
    }

    [HttpPatch("{id}/telemetry")]
    public async Task<IActionResult> UpdateTelemetry(Guid id, [FromBody] UpdateTelemetryDto telemetryDto)
    {
        var updatedMachine = await _machineService.UpdateTelemetryAsync(id, telemetryDto.Location, telemetryDto.Status);
        return updatedMachine == null ? NotFound() : Ok(updatedMachine);
    }
    
    
    
}