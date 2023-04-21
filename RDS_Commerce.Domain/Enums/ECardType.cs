using System.ComponentModel;

namespace RDS_Commerce.Domain.Enums;
public enum ECardType : ushort
{
    [Description("CREDIT_CARD")]
    CREDIT_CARD = 2,

    [Description("DEBIT_CARD")]
    DEBIT_CARD = 3,
}
