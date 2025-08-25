using System.ComponentModel.DataAnnotations;

namespace MachineMonitoring.Models;

public class Machine
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string Location { get; set; }
    
    public MachineStatus Status { get; set; }
    
}