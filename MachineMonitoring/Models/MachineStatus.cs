using System.Text.Json.Serialization;
using System.Runtime.Serialization;                                                                                                                              

namespace MachineMonitoring.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MachineStatus
{
    [EnumMember(Value = "operando")]
    Operando,

    [EnumMember(Value = "parada para manutenção")]
    ParadaManutencao,

    [EnumMember(Value = "desligada")]
    Desligada
    
}