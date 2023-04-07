using System.ComponentModel;

namespace RDS_Commerce.Domain.Enums;
public enum EBillingType : ushort
{
    [Description("BOLETO")]
    BOLETO = 1,

    [Description("CREDIT_CARD")]
    CREDIT_CARD = 2,

    [Description("DEBIT_CARD")]
    DEBIT_CARD = 3,

    [Description("UNDEFINED")]
    UNDEFINED = 4,

    [Description("TRANSFER")]
    TRANSFER = 5,

    [Description("DEPOSIT")]
    DEPOSIT = 6,

    [Description("PIX")]
    PIX = 7
}
