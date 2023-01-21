using System.ComponentModel;

namespace RDS_Commerce.Domain.Enums;
public enum EPlantType : ushort
{
    [Description("Comum")]
    Common = 1,

    [Description("Especial")]
    Special,

    [Description("Raro")]
    Rare
}
