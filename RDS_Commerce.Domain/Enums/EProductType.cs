using System.ComponentModel;

namespace RDS_Commerce.Domain.Enums;
public enum EProductType : ushort
{
    [Description("Comum")]
    Common = 1,

    [Description("Especial")]
    Special,

    [Description("Raro")]
    Rare
}
