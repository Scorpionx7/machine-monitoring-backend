using System.Text.Json.Serialization;

namespace MachineMonitoring.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MachineStatus
{
    Operando,
    ParadaManutencao,
    Desligada
    
}