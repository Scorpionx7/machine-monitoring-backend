using System.ComponentModel.DataAnnotations;

namespace MachineMonitoring.DTOs;

public class CreateMachineDto
{
    [Required] 
    public string Name { get; set; }

    [Required]
    public string Location { get; set; }
}