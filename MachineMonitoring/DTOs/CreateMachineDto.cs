using System.ComponentModel.DataAnnotations;
using MachineMonitoring.Models;

namespace MachineMonitoring.DTOs;

public class CreateMachineDto
{
    [Required] 
    public string Name { get; set; }

    [Required]
    public string Location { get; set; }
    
    public MachineStatus Status { get; set; } 
}